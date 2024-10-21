import 'package:flutter/widgets.dart';
import 'package:provider/provider.dart';

import '../../models/connection.dart';
import '../../models/entity.dart';
import '../../models/attribute.dart';
import '../../models/relationship.dart';
import '../../providers/diagram.dart';
import '../intents/add_connection.dart';
import '../utils.dart';

class AddConnectionAction extends ContextAction<AddConnectionIntent> {
  @override
  Object? invoke(AddConnectionIntent intent, [BuildContext? context]) {
    if (context == null) {
      return null;
    }

    final diagramProvider = context.read<DiagramProvider>();

    bool hasEntity = false;
    bool hasAttribute = false;
    bool hasRelationship = false;

    for (final element in intent.elements) {
      if (element is Entity) {
        hasEntity = true;
      } else if (element is Attribute) {
        hasAttribute = true;
      } else if (element is Relationship) {
        hasRelationship = true;
      }
    }

    if (hasEntity && hasAttribute) {
      _handleEntityWithAttribute(
        diagramProvider,
        intent.elements.firstWhere((e) => e is Entity) as Entity,
        intent.elements.firstWhere((e) => e is Attribute) as Attribute,
      );
    } else if (hasRelationship && hasAttribute) {
      _handleRelationshipWithAttribute(
        diagramProvider,
        intent.elements.firstWhere((e) => e is Relationship) as Relationship,
        intent.elements.firstWhere((e) => e is Attribute) as Attribute,
      );
    } else if (hasEntity && hasRelationship) {
      _handleEntityWithRelationship(
        diagramProvider,
        intent.elements.firstWhere((e) => e is Entity) as Entity,
        intent.elements.firstWhere((e) => e is Relationship) as Relationship,
      );
    } else if (hasEntity && !hasAttribute && !hasRelationship) {
      _handleEntityWithEntity(
        diagramProvider,
        intent.elements.firstWhere((e) => e is Entity) as Entity,
        intent.elements.lastWhere((e) => e is Entity) as Entity,
      );
    } else if (hasAttribute && !hasEntity && !hasRelationship) {
      _handleAttributeWithAttribute(
        diagramProvider,
        intent.elements.firstWhere((e) => e is Attribute) as Attribute,
        intent.elements.lastWhere((e) => e is Attribute) as Attribute,
      );
    }

    return null;
  }

  static void _handleEntityWithAttribute(DiagramProvider diagramProvider, Entity entity, Attribute attribute) {
    if (attribute.type == AttributeType.composite) {
      // remove all attribute connections except with other attributes
      diagramProvider.connections
          .where((connection) => connection.elements.contains(attribute))
          .where((connection) => connection.elements.any((element) => element is! Attribute))
          .toList()
          .forEach((connection) => diagramProvider.deleteConnection(connection.id));
    } else {
      // remove all attribute connections
      diagramProvider.connections
          .where((connection) => connection.elements.contains(attribute))
          .toList()
          .forEach((connection) => diagramProvider.deleteConnection(connection.id));
    }

    diagramProvider.addConnection(
      Connection(
        id: Utils.generateId(),
        elements: [entity, attribute],
      ),
    );
  }

  static void _handleRelationshipWithAttribute(DiagramProvider diagramProvider, Relationship relationship, Attribute attribute) {
    if (attribute.type == AttributeType.composite) {
      // remove all attribute connections except with other attributes
      diagramProvider.connections
          .where((connection) => connection.elements.contains(attribute))
          .where((connection) => connection.elements.any((element) => element is! Attribute))
          .toList()
          .forEach((connection) => diagramProvider.deleteConnection(connection.id));
    } else {
      // remove all attribute connections
      diagramProvider.connections
          .where((connection) => connection.elements.contains(attribute))
          .toList()
          .forEach((connection) => diagramProvider.deleteConnection(connection.id));
    }

    diagramProvider.addConnection(
      Connection(
        id: Utils.generateId(),
        elements: [relationship, attribute],
      ),
    );
  }

  static void _handleEntityWithRelationship(DiagramProvider diagramProvider, Entity entity, Relationship relationship) {
    diagramProvider.addConnection(
      RelationshipConnection(
        id: Utils.generateId(),
        elements: [relationship, entity],
      ),
      ifNotExist: false,
    );
  }

  static void _handleEntityWithEntity(DiagramProvider diagramProvider, Entity entity, Entity otherEntity) {
    if (otherEntity.type == EntityType.associative || entity.type == EntityType.associative) {
      diagramProvider.addConnection(
        RelationshipConnection(
          id: Utils.generateId(),
          elements: [otherEntity, entity],
          connectionPosition: ConnectionPosition.left,
        ),
      );
    }
  }

  static void _handleAttributeWithAttribute(DiagramProvider diagramProvider, Attribute attribute, Attribute otherAttribute) {
    if (attribute.type != AttributeType.composite && otherAttribute.type != AttributeType.composite) {
      return;
    }

    if (attribute.type == AttributeType.composite && otherAttribute.type == AttributeType.composite) {
      return;
    }

    Attribute theNormalOne = (attribute.type == AttributeType.composite) ? otherAttribute : attribute;
    Attribute theCompositeOne = (attribute.type == AttributeType.composite) ? attribute : otherAttribute;

    diagramProvider.connections
        .where((connection) => connection.elements.contains(theNormalOne))
        .toList()
        .forEach((connection) => diagramProvider.deleteConnection(connection.id));

    diagramProvider.addConnection(
      Connection(
        id: Utils.generateId(),
        elements: [theCompositeOne, theNormalOne],
      ),
    );
  }
}
