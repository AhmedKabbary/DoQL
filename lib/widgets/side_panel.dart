import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../models/attribute.dart';
import '../models/entity.dart';
import '../models/relationship.dart';
import '../providers/active_element.dart';
import 'side_panels/attribute.dart';
import 'side_panels/diagram.dart';
import 'side_panels/entity.dart';
import 'side_panels/relationship.dart';

class SidePanel extends StatelessWidget {
  const SidePanel({super.key});

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: 320,
      child: ColoredBox(
        color: Theme.of(context).colorScheme.surfaceContainer,
        child: Consumer<ActiveElementProvider>(
          builder: (context, activeElementProvider, _) {
            final element = activeElementProvider.activeElement;
            return switch (element) {
              Entity element => EntitySidePanel(key: ValueKey(element.id), entity: element),
              Attribute element => AttributeSidePanel(key: ValueKey(element.id), attribute: element),
              Relationship element => RelationshipSidePanel(key: ValueKey(element.id), relationship: element),
              _ => const DiagramSidePanel(),
            };
          },
        ),
      ),
    );
  }
}
