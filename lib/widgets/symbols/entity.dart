import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../../models/entity.dart';
import '../../providers/pseudo_connection.dart';
import '../../utilities/painters/entity.dart';
import '../../utilities/intents/move_element.dart';
import '../../utilities/intents/add_connection.dart';
import 'erd_symbol.dart';

class EntitySymbol extends StatelessWidget {
  const EntitySymbol({
    super.key,
    required this.entity,
  });

  final Entity entity;

  @override
  Widget build(BuildContext context) {
    return ErdSymbol(
      element: entity,
      painter: EntityPainter(
        type: entity.type,
        backgroundColor: Theme.of(context).colorScheme.surface,
      ),
      child: Padding(
        padding: const EdgeInsets.all(24),
        child: Text(
          entity.label,
          maxLines: 1,
          overflow: TextOverflow.ellipsis,
          style: Theme.of(context).textTheme.bodyMedium?.copyWith(color: Colors.white),
        ),
      ),
      onMove: (details) => Actions.invoke(context, MoveElementIntent(element: entity, delta: details.delta)),
      onConnection: () {
        final pseudoConnection = context.read<PseudoConnection>();
        final startElement = pseudoConnection.startElement;
        if (startElement == entity) return;

        if (startElement != null) {
          Actions.invoke(context, AddConnectionIntent(elements: [startElement, entity]));
        }
      },
    );
  }
}
