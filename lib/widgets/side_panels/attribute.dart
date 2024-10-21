import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../../models/attribute.dart';
import '../../models/connection.dart';
import '../../providers/active_element.dart';
import '../../providers/diagram.dart';

class AttributeSidePanel extends StatelessWidget {
  const AttributeSidePanel({
    super.key,
    required this.attribute,
  });

  final Attribute attribute;

  @override
  Widget build(BuildContext context) {
    return ListView(
      children: [
        Padding(
          padding: const EdgeInsets.all(16),
          child: TextFormField(
            initialValue: attribute.label,
            decoration: const InputDecoration(
              border: OutlineInputBorder(),
              labelText: 'Name',
            ),
            onChanged: (value) {
              attribute.label = value;
              context.read<DiagramProvider>().updateElement(attribute);
            },
          ),
        ),
        Consumer<DiagramProvider>(
          builder: (context, diagramProvider, child) {
            bool isReallyComposite = false;
            if (attribute.type == AttributeType.composite) {
              isReallyComposite = diagramProvider.connections
                  .any((connection) => connection.elements.contains(attribute) && connection.elements.every((element) => element is Attribute));
            }

            return Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Padding(
                  padding: const EdgeInsets.only(left: 16, right: 16, bottom: 8),
                  child: Wrap(
                    children: [
                      Padding(
                        padding: const EdgeInsets.all(8),
                        child: ChoiceChip(
                          label: const Text('Normal'),
                          selected: attribute.type == AttributeType.normal,
                          onSelected: isReallyComposite
                              ? null
                              : (value) {
                                  attribute.type = AttributeType.normal;
                                  diagramProvider.updateElement(attribute);
                                },
                        ),
                      ),
                      Padding(
                        padding: const EdgeInsets.all(8),
                        child: ChoiceChip(
                          label: const Text('Key'),
                          selected: attribute.type == AttributeType.key,
                          onSelected: isReallyComposite
                              ? null
                              : (value) {
                                  attribute.type = AttributeType.key;
                                  diagramProvider.updateElement(attribute);
                                },
                        ),
                      ),
                      Padding(
                        padding: const EdgeInsets.all(8),
                        child: ChoiceChip(
                          label: const Text('Partial Key'),
                          selected: attribute.type == AttributeType.partialKey,
                          onSelected: isReallyComposite
                              ? null
                              : (value) {
                                  attribute.type = AttributeType.partialKey;
                                  diagramProvider.updateElement(attribute);
                                },
                        ),
                      ),
                      Padding(
                        padding: const EdgeInsets.all(8),
                        child: ChoiceChip(
                          label: const Text('Composite'),
                          selected: attribute.type == AttributeType.composite,
                          onSelected: isReallyComposite
                              ? null
                              : (value) {
                                  attribute.type = AttributeType.composite;
                                  diagramProvider.updateElement(attribute);
                                },
                        ),
                      ),
                      Padding(
                        padding: const EdgeInsets.all(8),
                        child: ChoiceChip(
                          label: const Text('Multivalued'),
                          selected: attribute.type == AttributeType.multivalued,
                          onSelected: isReallyComposite
                              ? null
                              : (value) {
                                  attribute.type = AttributeType.multivalued;
                                  diagramProvider.updateElement(attribute);
                                },
                        ),
                      ),
                      Padding(
                        padding: const EdgeInsets.all(8),
                        child: ChoiceChip(
                          label: const Text('Derived'),
                          selected: attribute.type == AttributeType.derived,
                          onSelected: isReallyComposite
                              ? null
                              : (value) {
                                  attribute.type = AttributeType.derived;
                                  diagramProvider.updateElement(attribute);
                                },
                        ),
                      ),
                    ],
                  ),
                ),
                Builder(
                  builder: (context) {
                    final connections = diagramProvider.connections
                        .whereType<Connection>()
                        .where((connection) => connection.elements.any((element) => element.id == attribute.id))
                        .where((connection) => connection.elements.every((element) => element is Attribute))
                        .toList();

                    if (attribute.type != AttributeType.composite || connections.isEmpty) {
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
                            final otherAttribute = connection.elements.firstWhere((element) => element.id != attribute.id) as Attribute;

                            return ListTile(
                              title: Text(otherAttribute.label),
                              trailing: IconButton(
                                icon: const Icon(Icons.delete),
                                onPressed: () {
                                  diagramProvider.deleteConnection(connection.id);
                                },
                              ),
                              onTap: () {
                                context.read<ActiveElementProvider>().setActiveElement(otherAttribute);
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
