import 'package:flutter/widgets.dart';
import 'package:provider/provider.dart';

import '../../models/entity.dart';
import '../../models/attribute.dart';
import '../../models/relationship.dart';
import '../../providers/diagram.dart';
import '../intents/move_element.dart';

class MoveElementAction extends ContextAction<MoveElementIntent> {
  @override
  Object? invoke(MoveElementIntent intent, [BuildContext? context]) {
    if (context == null) {
      return null;
    }

    final diagramProvider = context.read<DiagramProvider>();

    switch (intent.element) {
      case Entity entity:
        _moveEntity(diagramProvider, entity, intent.delta);
        break;
      case Attribute attribute:
        _moveAttribute(diagramProvider, attribute, intent.delta);
        break;
      case Relationship relationship:
        _moveRelationship(diagramProvider, relationship, intent.delta);
        break;
    }

    diagramProvider.refresh();

    return null;
  }

  static void _moveEntity(DiagramProvider diagramProvider, Entity entity, Offset delta) {
    entity.position += delta;

    for (var connection in diagramProvider.connections) {
      if (connection.elements.any((element) => element.id == entity.id)) {
        for (var element in connection.elements) {
          if (element is Attribute) {
            _moveAttribute(diagramProvider, element, delta);
          }
        }
      }
    }
  }

  static void _moveRelationship(DiagramProvider diagramProvider, Relationship relationship, Offset delta) {
    relationship.position += delta;

    for (var connection in diagramProvider.connections) {
      if (connection.elements.any((element) => element.id == relationship.id)) {
        for (var element in connection.elements) {
          if (element is Attribute) {
            _moveAttribute(diagramProvider, element, delta);
          }
        }
      }
    }
  }

  static void _moveAttribute(DiagramProvider diagramProvider, Attribute attribute, Offset delta) {
    attribute.position += delta;

    if (attribute.type == AttributeType.composite) {
      for (var connection in diagramProvider.connections) {
        if (connection.elements.any((element) => element.id == attribute.id)) {
          for (var element in connection.elements) {
            if (element is Attribute && element.id != attribute.id) {
              _moveAttribute(diagramProvider, element, delta);
            }
          }
        }
      }
    }
  }
}
