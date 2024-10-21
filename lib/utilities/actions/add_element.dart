import 'package:flutter/widgets.dart';
import 'package:provider/provider.dart';

import '../../models/attribute.dart';
import '../../models/entity.dart';
import '../../models/relationship.dart';
import '../../providers/diagram.dart';
import '../../providers/offset.dart';
import '../intents/add_element.dart';
import '../utils.dart';

class AddEntityAction extends ContextAction<AddEntityIntent> {
  @override
  Object? invoke(AddEntityIntent intent, [BuildContext? context]) {
    if (context == null) {
      return null;
    }

    final offsetProvider = context.read<OffsetProvider>();
    final diagramProvider = context.read<DiagramProvider>();

    Offset? position = intent.position;
    position ??= diagramProvider.diagramSize.center(const Offset(-50, -50));

    diagramProvider.addElement(
      Entity(
        id: Utils.generateId(),
        label: 'Entity',
        position: position - offsetProvider.offset,
      ),
    );

    return null;
  }
}

class AddAttributeAction extends ContextAction<AddAttributeIntent> {
  @override
  Object? invoke(AddAttributeIntent intent, [BuildContext? context]) {
    if (context == null) {
      return null;
    }

    final offsetProvider = context.read<OffsetProvider>();
    final diagramProvider = context.read<DiagramProvider>();

    Offset? position = intent.position;
    position ??= diagramProvider.diagramSize.center(const Offset(-50, -50));

    diagramProvider.addElement(
      Attribute(
        id: Utils.generateId(),
        label: 'Attribute',
        position: position - offsetProvider.offset,
      ),
    );

    return null;
  }
}

class AddRelationshipAction extends ContextAction<AddRelationshipIntent> {
  @override
  Object? invoke(AddRelationshipIntent intent, [BuildContext? context]) {
    if (context == null) {
      return null;
    }

    final offsetProvider = context.read<OffsetProvider>();
    final diagramProvider = context.read<DiagramProvider>();

    Offset? position = intent.position;
    position ??= diagramProvider.diagramSize.center(const Offset(-50, -50));

    diagramProvider.addElement(
      Relationship(
        id: Utils.generateId(),
        label: 'Relationship',
        position: position - offsetProvider.offset,
      ),
    );

    return null;
  }
}
