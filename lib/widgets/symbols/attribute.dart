import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../../models/attribute.dart';
import '../../providers/pseudo_connection.dart';
import '../../utilities/clippers/attribute.dart';
import '../../utilities/intents/move_element.dart';
import '../../utilities/painters/attribute.dart';
import '../../utilities/intents/add_connection.dart';
import 'erd_symbol.dart';

class AttributeSymbol extends StatelessWidget {
  const AttributeSymbol({
    super.key,
    required this.attribute,
  });

  final Attribute attribute;

  @override
  Widget build(BuildContext context) {
    return ErdSymbol(
      element: attribute,
      clipper: AttributeClipper(),
      painter: AttributePainter(type: attribute.type),
      child: Padding(
        padding: const EdgeInsets.all(24),
        child: Text(
          attribute.label,
          maxLines: 1,
          overflow: TextOverflow.ellipsis,
          style: Theme.of(context).textTheme.bodyMedium?.copyWith(
                color: Colors.black,
                decoration: attribute.type == AttributeType.key || attribute.type == AttributeType.partialKey ? TextDecoration.underline : null,
              ),
        ),
      ),
      onMove: (details) => Actions.invoke(context, MoveElementIntent(element: attribute, delta: details.delta)),
      onConnection: () {
        final pseudoConnection = context.read<PseudoConnection>();
        final startElement = pseudoConnection.startElement;
        if (startElement == attribute) return;

        if (startElement != null) {
          Actions.invoke(context, AddConnectionIntent(elements: [startElement, attribute]));
        }
      },
    );
  }
}
