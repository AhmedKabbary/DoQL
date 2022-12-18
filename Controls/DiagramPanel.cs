using System.Collections.ObjectModel;
using System.Drawing.Drawing2D;
using DoQL.Controls.ERD;
using DoQL.Forms;
using DoQL.Interfaces;
using DoQL.Models.ERD;
using DoQL.Utilities;

namespace DoQL.Controls
{
    public partial class DiagramPanel : UserControl
    {
        public DiagramPanel()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Connections = new ObservableCollection<Connection>();
        }

        protected override void OnLoad(EventArgs e)
        {
            var diagramPanel = this;
            var database = (Parent as DiagramForm).Database;

            // load ERD data on the panel
            foreach (var attribute in database.Erd.Attributes)
            {
                var control = new AttributeControl() { Id = attribute.Id };
                control.Location = attribute.Position;
                diagramPanel.Controls.Add(control);
            }

            foreach (var entity in database.Erd.Entities)
            {
                var control = new EntityControl() { Id = entity.Id };
                control.Location = entity.Position;
                diagramPanel.Controls.Add(control);

                // load attached attributes connections
                foreach (var attachedAttribute in entity.AttributesReferences)
                {
                    diagramPanel.Connections.Add(new Connection
                    {
                        Control1 = new Connection.ControlConnector
                        {
                            ConnectableControl = control,
                            ConnectorId = attachedAttribute.ParentConnectorIndex,
                        },
                        Control2 = new Connection.ControlConnector
                        {
                            ConnectableControl = diagramPanel.Controls.OfType<AttributeControl>().First(a => a.Id == attachedAttribute.AttributeId),
                            ConnectorId = attachedAttribute.AttributeConnectorIndex,
                        },
                    });
                }
            }

            foreach (var relationship in database.Erd.Relationships)
            {
                var control = new RelationshipControl() { Id = relationship.Id };
                control.Location = relationship.Position;
                diagramPanel.Controls.Add(control);

                // load attached entities connections
                foreach (var attachedEntity in relationship.Entities)
                {
                    diagramPanel.Connections.Add(new Connection
                    {
                        Control1 = new Connection.ControlConnector
                        {
                            ConnectableControl = control,
                            ConnectorId = attachedEntity.RelationshipConnectorIndex,
                        },
                        Control2 = new Connection.ControlConnector
                        {
                            ConnectableControl = diagramPanel.Controls.OfType<EntityControl>().First(a => a.Id == attachedEntity.EntityId),
                            ConnectorId = attachedEntity.EntityConnectorIndex,
                        },
                    });
                }

                // load attached attributes connections
                foreach (var attachedAttribute in relationship.Attributes)
                {
                    diagramPanel.Connections.Add(new Connection
                    {
                        Control1 = new Connection.ControlConnector
                        {
                            ConnectableControl = control,
                            ConnectorId = attachedAttribute.ParentConnectorIndex,
                        },
                        Control2 = new Connection.ControlConnector
                        {
                            ConnectableControl = diagramPanel.Controls.OfType<AttributeControl>().First(a => a.Id == attachedAttribute.AttributeId),
                            ConnectorId = attachedAttribute.AttributeConnectorIndex,
                        },
                    });
                }
            }
            base.OnLoad(e);
        }

        #region dragging

        private bool _selected;
        private Point _point;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _selected = true;
            _point = e.Location;
            Cursor = Cursors.Hand;
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_selected)
            {
                foreach (IMovable movableControl in Controls.OfType<IMovable>())
                {
                    movableControl.Move(new Point(e.X - _point.X, e.Y - _point.Y));
                }
                _point = e.Location;
                RedrawCardinalities();
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _selected = false;
            Cursor = Cursors.Default;
            base.OnMouseUp(e);
        }

        #endregion

        #region connections drawing

        public ObservableCollection<Connection> Connections { get; set; }

        public void RedrawCardinalities() => Invalidate();

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var pen = new Pen(Brushes.Gray, 2);
            foreach (var connection in Connections)
            {
                Point p1;
                Point p2;

                if (connection.Control1.IsValidConnection())
                {
                    p1 = MapChildPointToThis(connection.Control1.ConnectableControl as Control, connection.Control1.ConnectableControl.GetConnectablePoints()[connection.Control1.ConnectorId]);
                }
                else p1 = connection.Control1.Position;

                if (connection.Control2.IsValidConnection())
                {
                    p2 = MapChildPointToThis(connection.Control2.ConnectableControl as Control, connection.Control2.ConnectableControl.GetConnectablePoints()[connection.Control2.ConnectorId]);
                }
                else p2 = connection.Control2.Position;

                e.Graphics.DrawLine(pen, p1, p2);
            }
            base.OnPaint(e);
        }

        public static Point MapChildPointToThis(Control control, Point point)
        {
            point.Offset(control.Location);
            return point;
        }

        public void RemoveConnection(Connection connection)
        {
            if (connection.IsValidConnection())
            {
                DiagramForm diagramForm = (Parent as DiagramForm);

                bool isEntity = connection.Control1.ConnectableControl is EntityControl || connection.Control2.ConnectableControl is EntityControl;
                bool isAttribute = connection.Control1.ConnectableControl is AttributeControl || connection.Control2.ConnectableControl is AttributeControl;
                bool isRelationship = connection.Control1.ConnectableControl is RelationshipControl || connection.Control2.ConnectableControl is RelationshipControl;

                if (isEntity && isRelationship)
                {
                    Connection.ControlConnector rc;
                    Connection.ControlConnector ec;
                    if (connection.Control1.ConnectableControl is RelationshipControl)
                    {
                        rc = connection.Control1;
                        ec = connection.Control2;
                    }
                    else
                    {
                        rc = connection.Control2;
                        ec = connection.Control1;
                    }

                    Relationship relationship = diagramForm.Database.Erd.Relationships.Find(r => r.Id == (rc.ConnectableControl as RelationshipControl).Id);
                    relationship.Entities.RemoveAll(e => e.EntityId == (ec.ConnectableControl as EntityControl).Id);
                }
                if (isEntity && isAttribute)
                {
                    Connection.ControlConnector ac;
                    Connection.ControlConnector ec;
                    if (connection.Control1.ConnectableControl is AttributeControl)
                    {
                        ac = connection.Control1;
                        ec = connection.Control2;
                    }
                    else
                    {
                        ac = connection.Control2;
                        ec = connection.Control1;
                    }

                    Entity entity = diagramForm.Database.Erd.Entities.Find(e => e.Id == (ec.ConnectableControl as EntityControl).Id);
                    entity.AttributesReferences.RemoveAll(a => a.AttributeId == (ac.ConnectableControl as AttributeControl).Id);
                }
                if (isRelationship && isAttribute)
                {
                    Connection.ControlConnector ac;
                    Connection.ControlConnector rc;
                    if (connection.Control1.ConnectableControl is AttributeControl)
                    {
                        ac = connection.Control1;
                        rc = connection.Control2;
                    }
                    else
                    {
                        ac = connection.Control2;
                        rc = connection.Control1;
                    }


                    Relationship relationship = diagramForm.Database.Erd.Relationships.Find(r => r.Id == (rc.ConnectableControl as RelationshipControl).Id);
                    relationship.Attributes.RemoveAll(a => a.AttributeId == (ac.ConnectableControl as AttributeControl).Id);
                }
            }
            Connections.Remove(connection);
        }

        #endregion

        #region symbols connectors visibility

        public void ShowConnectors(params ErdSymbol[] symbols)
        {
            foreach (var control in Controls.OfType<BaseControl>().ToList())
            {
                if (symbols.Contains(ErdSymbol.Entity))
                    if (control is EntityControl)
                        control.ShowConnectors();

                if (symbols.Contains(ErdSymbol.Attribute))
                    if (control is AttributeControl)
                        control.ShowConnectors();

                if (symbols.Contains(ErdSymbol.Relationship))
                    if (control is RelationshipControl)
                        control.ShowConnectors();
            }
        }

        public void HideAllConnectors()
        {
            foreach (var control in Controls.OfType<BaseControl>().ToList())
                control.HideConnectors();
        }

        #endregion

    }

    public class Connection
    {
        public ControlConnector Control1 { get; set; }
        public ControlConnector Control2 { get; set; }

        public bool IsValidConnection() => Control1.IsValidConnection() && Control2.IsValidConnection();

        public class ControlConnector
        {
            public Point Position { get; set; }
            public int ConnectorId { get; set; }
            public IConnectable ConnectableControl { get; set; }

            public bool IsValidConnection() => ConnectableControl != null;
        }
    }
}
