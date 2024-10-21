import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../../models/relationship.dart';
import '../../providers/pseudo_connection.dart';
import '../../utilities/clippers/relationship.dart';
import '../../utilities/intents/add_connection.dart';
import '../../utilities/intents/move_element.dart';
import '../../utilities/painters/relationship.dart';
import 'erd_symbol.dart';

class RelationshipSymbol extends StatelessWidget {
  const RelationshipSymbol({
    super.key,
    required this.relationship,
  });

  final Relationship relationship;

  @override
  Widget build(BuildContext context) {
    return ErdSymbol(
      element: relationship,
      clipper: RelationshipClipper(),
      painter: RelationshipPainter(
        type: relationship.type,
        backgroundColor: Theme.of(context).colorScheme.surface,
      ),
      child: SizedBox(
        width: 125,
        height: 125,
        child: Padding(
          padding: const EdgeInsets.all(24),
          child: Center(
            child: Text(
              relationship.label,
              maxLines: 2,
              textAlign: TextAlign.center,
              overflow: TextOverflow.ellipsis,
              style: Theme.of(context).textTheme.bodyMedium?.copyWith(color: Colors.white),
            ),
          ),
        ),
      ),
      onMove: (details) => Actions.invoke(context, MoveElementIntent(element: relationship, delta: details.delta)),
      onConnection: () {
        final pseudoConnection = context.read<PseudoConnection>();
        final startElement = pseudoConnection.startElement;
        if (startElement == relationship) return;

        if (startElement != null) {
          Actions.invoke(context, AddConnectionIntent(elements: [startElement, relationship]));
        }
      },
    );
  }
}
