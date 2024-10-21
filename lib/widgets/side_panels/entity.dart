import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../../models/attribute.dart';
import '../../models/connection.dart';
import '../../models/entity.dart';
import '../../providers/active_element.dart';
import '../../providers/diagram.dart';
import 'relationship.dart';

class EntitySidePanel extends StatelessWidget {
  const EntitySidePanel({
    super.key,
    required this.entity,
  });

  final Entity entity;

  @override
  Widget build(BuildContext context) {
    return ListView(
      children: [
        Padding(
          padding: const EdgeInsets.all(16),
          child: TextFormField(
            initialValue: entity.label,
            decoration: const InputDecoration(
              border: OutlineInputBorder(),
              labelText: 'Name',
            ),
            onChanged: (value) {
              entity.label = value;
              context.read<DiagramProvider>().updateElement(entity);
            },
          ),
        ),
        Consumer<DiagramProvider>(
          builder: (context, diagramProvider, child) {
            return Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Builder(
                  builder: (context) {
                    bool isReallyAssociative = false;
                    if (entity.type == EntityType.associative) {
                      isReallyAssociative = diagramProvider.connections
                          .any((connection) => connection.elements.contains(entity) && connection.elements.every((element) => element is Entity));
                    }

                    return Padding(
                      padding: const EdgeInsets.only(left: 16, right: 16, bottom: 8),
                      child: Wrap(
                        children: [
                          Padding(
                            padding: const EdgeInsets.all(8),
                            child: ChoiceChip(
                              label: const Text('Strong'),
                              selected: entity.type == EntityType.strong,
                              onSelected: isReallyAssociative
                                  ? null
                                  : (value) {
                                      entity.type = EntityType.strong;
                                      diagramProvider.updateElement(entity);
                                    },
                            ),
                          ),
                          Padding(
                            padding: const EdgeInsets.all(8),
                            child: ChoiceChip(
                              label: const Text('Weak'),
                              selected: entity.type == EntityType.weak,
                              onSelected: isReallyAssociative
                                  ? null
                                  : (value) {
                                      entity.type = EntityType.weak;
                                      diagramProvider.updateElement(entity);
                                    },
                            ),
                          ),
                          Padding(
                            padding: const EdgeInsets.all(8),
                            child: ChoiceChip(
                              label: const Text('Associative'),
                              selected: entity.type == EntityType.associative,
                              onSelected: isReallyAssociative
                                  ? null
                                  : (value) {
                                      entity.type = EntityType.associative;
                                      diagramProvider.updateElement(entity);
                                    },
                            ),
                          ),
                        ],
                      ),
                    );
                  },
                ),
                Builder(
                  builder: (context) {
                    if (entity.type != EntityType.associative) {
                      return const SizedBox.shrink();
                    }

                    final connections = diagramProvider
                        .getElementConnections(entity.id)
                        .whereType<RelationshipConnection>()
                        .where((connection) => connection.elements.every((element) => element is Entity));

                    return Column(
                      children: [
                        for (var connection in connections)
                          AttachedConnectionWidget(
                            connection: connection,
                            currentElementId: entity.id,
                          )
                      ],
                    );
                  },
                ),
                Builder(
                  builder: (context) {
                    final connections = diagramProvider.connections
                        .whereType<Connection>()
                        .where((connection) => connection.elements.any((element) => element.id == entity.id))
                        .where((connection) => connection.elements.any((element) => element is Attribute))
                        .toList();

                    if (connections.isEmpty) {
                      return const SizedBox.shrink();
                    }

                    return Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        const Divider(),
                        Padding(
                          padding: const EdgeInsets.all(16),
                          child: Text(
                            'Attributes',
                            style: Theme.of(context).textTheme.titleMedium,
                          ),
                        ),
                        ListView.builder(
                          shrinkWrap: true,
                          physics: const NeverScrollableScrollPhysics(),
                          itemCount: connections.length,
                          itemBuilder: (context, index) {
                            final connection = connections[index];
                            final attribute = connection.elements.whereType<Attribute>().first;

                            return ListTile(
                              title: Text(attribute.label),
                              trailing: IconButton(
                                icon: const Icon(Icons.delete),
                                onPressed: () {
                                  diagramProvider.deleteConnection(connection.id);
                                },
                              ),
                              onTap: () {
                                context.read<ActiveElementProvider>().setActiveElement(attribute);
                              },
                            );
                          },
                        ),
                      ],
                    );
                  },
                ),
              ],
            );
          },
        ),
      ],
    );
  }
}
