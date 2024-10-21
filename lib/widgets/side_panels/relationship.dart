import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../../models/connection.dart';
import '../../models/entity.dart';
import '../../models/relationship.dart';
import '../../providers/active_element.dart';
import '../../providers/diagram.dart';

class RelationshipSidePanel extends StatelessWidget {
  const RelationshipSidePanel({
    super.key,
    required this.relationship,
  });

  final Relationship relationship;

  @override
  Widget build(BuildContext context) {
    return ListView(
      children: [
        Padding(
          padding: const EdgeInsets.all(16),
          child: TextFormField(
            initialValue: relationship.label,
            decoration: const InputDecoration(
              border: OutlineInputBorder(),
              labelText: 'Name',
            ),
            onChanged: (value) {
              relationship.label = value;
              context.read<DiagramProvider>().updateElement(relationship);
            },
          ),
        ),
        Consumer<DiagramProvider>(
          builder: (context, diagramProvider, child) {
            final connections = diagramProvider.getElementConnections(relationship.id).whereType<RelationshipConnection>();

            return Column(
              children: [
                Padding(
                  padding: const EdgeInsets.only(left: 16, right: 16, bottom: 8),
                  child: Row(
                    children: [
                      Padding(
                        padding: const EdgeInsets.all(8),
                        child: ChoiceChip(
                          label: const Text('Strong'),
                          selected: relationship.type == RelationshipType.strong,
                          onSelected: (value) {
                            relationship.type = RelationshipType.strong;
                            diagramProvider.updateElement(relationship);
                          },
                        ),
                      ),
                      Padding(
                        padding: const EdgeInsets.all(8),
                        child: ChoiceChip(
                          label: const Text('Weak'),
                          selected: relationship.type == RelationshipType.weak,
                          onSelected: (value) {
                            relationship.type = RelationshipType.weak;
                            diagramProvider.updateElement(relationship);
                          },
                        ),
                      ),
                    ],
                  ),
                ),
                for (final connection in connections)
                  AttachedConnectionWidget(
                    connection: connection,
                    currentElementId: relationship.id,
                  ),
              ],
            );
          },
        ),
      ],
    );
  }
}

class AttachedConnectionWidget extends StatelessWidget {
  const AttachedConnectionWidget({
    super.key,
    required this.connection,
    required this.currentElementId,
  });

  final String currentElementId;
  final RelationshipConnection connection;

  @override
  Widget build(BuildContext context) {
    final diagramProvider = context.read<DiagramProvider>();
    final activeElementProvider = context.read<ActiveElementProvider>();

    final entity = connection.elements.firstWhere((element) => element.id != currentElementId) as Entity;

    return Column(
      children: [
        const Divider(),
        ListTile(
          title: Text(entity.label),
          trailing: IconButton(
            icon: const Icon(Icons.delete_rounded),
            onPressed: () {
              diagramProvider.deleteConnection(connection.id);
            },
          ),
          onTap: () => activeElementProvider.setActiveElement(entity),
          contentPadding: const EdgeInsets.only(left: 16, right: 12),
        ),
        Padding(
          padding: const EdgeInsets.all(8),
          child: Column(
            children: [
              Padding(
                padding: const EdgeInsets.symmetric(horizontal: 8),
                child: Row(
                  children: [
                    Padding(
                      padding: const EdgeInsets.all(8),
                      child: ChoiceChip(
                        label: const Text('One'),
                        selected: connection.cardinality == Cardinality.one,
                        onSelected: (value) {
                          connection.cardinality = Cardinality.one;
                          diagramProvider.updateConnection(connection);
                        },
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.all(8),
                      child: ChoiceChip(
                        label: const Text('Many'),
                        selected: connection.cardinality == Cardinality.many,
                        onSelected: (value) {
                          connection.cardinality = Cardinality.many;
                          diagramProvider.updateConnection(connection);
                        },
                      ),
                    ),
                  ],
                ),
              ),
              Padding(
                padding: const EdgeInsets.symmetric(horizontal: 8),
                child: Row(
                  children: [
                    Padding(
                      padding: const EdgeInsets.all(8),
                      child: ChoiceChip(
                        label: const Text('Total'),
                        selected: connection.participation == Participation.total,
                        onSelected: (value) {
                          connection.participation = Participation.total;
                          diagramProvider.updateConnection(connection);
                        },
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.all(8),
                      child: ChoiceChip(
                        label: const Text('Partial'),
                        selected: connection.participation == Participation.partial,
                        onSelected: (value) {
                          connection.participation = Participation.partial;
                          diagramProvider.updateConnection(connection);
                        },
                      ),
                    ),
                  ],
                ),
              ),
              Padding(
                padding: const EdgeInsets.symmetric(horizontal: 8),
                child: Row(
                  children: [
                    Padding(
                      padding: const EdgeInsets.all(8),
                      child: ChoiceChip(
                        label: const Text('Mandatory'),
                        selected: connection.optionality == Optionality.mandatory,
                        onSelected: (value) {
                          connection.optionality = Optionality.mandatory;
                          diagramProvider.updateConnection(connection);
                        },
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.all(8),
                      child: ChoiceChip(
                        label: const Text('Optional'),
                        selected: connection.optionality == Optionality.optional,
                        onSelected: (value) {
                          connection.optionality = Optionality.optional;
                          diagramProvider.updateConnection(connection);
                        },
                      ),
                    ),
                  ],
                ),
              ),
              Padding(
                padding: const EdgeInsets.symmetric(horizontal: 8),
                child: Row(
                  children: [
                    Padding(
                      padding: const EdgeInsets.all(8),
                      child: ChoiceChip(
                        label: const Text('T'),
                        selected: connection.connectionPosition == ConnectionPosition.top,
                        onSelected: (value) {
                          connection.connectionPosition = ConnectionPosition.top;
                          diagramProvider.updateConnection(connection);
                        },
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.all(8),
                      child: ChoiceChip(
                        label: const Text('L'),
                        selected: connection.connectionPosition == ConnectionPosition.left,
                        onSelected: (value) {
                          connection.connectionPosition = ConnectionPosition.left;
                          diagramProvider.updateConnection(connection);
                        },
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.all(8),
                      child: ChoiceChip(
                        label: const Text('R'),
                        selected: connection.connectionPosition == ConnectionPosition.right,
                        onSelected: (value) {
                          connection.connectionPosition = ConnectionPosition.right;
                          diagramProvider.updateConnection(connection);
                        },
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.all(8),
                      child: ChoiceChip(
                        label: const Text('B'),
                        selected: connection.connectionPosition == ConnectionPosition.bottom,
                        onSelected: (value) {
                          connection.connectionPosition = ConnectionPosition.bottom;
                          diagramProvider.updateConnection(connection);
                        },
                      ),
                    ),
                  ],
                ),
              ),
            ],
          ),
        ),
      ],
    );
  }
}
