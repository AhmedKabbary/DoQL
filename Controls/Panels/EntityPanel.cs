using DoQL.Controls.ERD;
using DoQL.Forms;
using DoQL.Models.ERD;

namespace DoQL.Controls.Panels
{
    public partial class EntityPanel : UserControl
    {
        public string Id { get; init; }
        public EntityControl EntityControl { get; init; }

        public EntityPanel()
        {
            InitializeComponent();
        }

        private Entity _entity { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            _entity = (ParentForm as DiagramForm).Database.Erd.Entities.Find(e => e.Id == Id);
            entityName.Text = _entity.DisplayName;
            tableName.Text = _entity.TableName;
            base.OnLoad(e);
        }

        private void ChangeEntityName(object sender, EventArgs e)
        {
            _entity.DisplayName = entityName.Text;
            EntityControl.SetDisplayName(entityName.Text);
        }

        private void ChangeTableName(object sender, EventArgs e)
        {
            _entity.TableName = tableName.Text;
        }
    }
}
