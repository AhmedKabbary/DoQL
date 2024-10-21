import 'dart:convert';
import 'dart:typed_data';

import 'package:flutter/rendering.dart';

import '../models/attribute.dart';
import '../models/connection.dart';
import '../models/entity.dart';
import '../models/relationship.dart';
import '../providers/diagram.dart';

class StorageService {
  static const version = 0;

  static Uint8List encode(DiagramProvider diagramProvider) {
    final entities = [];
    final attributes = [];
    final relationships = [];
    final connections = [];

    for (final element in diagramProvider.elements.values) {
      final map = {};
      map['id'] = element.id;
      map['position'] = {
        'x': element.position.dx,
        'y': element.position.dy,
      };

      switch (element) {
        case Entity element:
          map['label'] = element.label;
          map['type'] = element.type.index;
          entities.add(map);
          break;
        case Attribute element:
          map['label'] = element.label;
          map['type'] = element.type.index;
          attributes.add(map);
          break;
        case Relationship element:
          map['label'] = element.label;
          map['type'] = element.type.index;
          relationships.add(map);
          break;
        default:
      }
    }

    for (final connection in diagramProvider.connections) {
      final map = {};
      map['id'] = connection.id;
      map['elements'] = connection.elements.map((e) => e.id).toList();

      if (connection is RelationshipConnection) {
        map['cardinality'] = connection.cardinality.index;
        map['optionality'] = connection.optionality.index;
        map['participation'] = connection.participation.index;
        map['connectionPosition'] = connection.connectionPosition.index;
      }

      connections.add(map);
    }

    final map = {
      'version': version,
      'diagram': {
        'entities': entities,
        'attributes': attributes,
        'relationships': relationships,
        'connections': connections,
      }
    };

    String json = jsonEncode(map);
    return utf8.encode(json);
  }

  static DiagramProvider decode(Uint8List bytes) {
    String json = utf8.decode(bytes);
    final map = jsonDecode(json);

    if (map['version'] != version) {
      throw Exception('Invalid version');
    }

    final diagramProvider = DiagramProvider();
    final entities = map['diagram']['entities'];
    final attributes = map['diagram']['attributes'];
    final relationships = map['diagram']['relationships'];
    final connections = map['diagram']['connections'];

    for (final entity in entities) {
      final object = Entity(
        id: entity['id'],
        position: Offset(entity['position']['x'], entity['position']['y']),
        label: entity['label'],
        type: EntityType.values[entity['type']],
      );
      diagramProvider.addElement(object);
    }

    for (final attribute in attributes) {
      final object = Attribute(
        id: attribute['id'],
        position: Offset(attribute['position']['x'], attribute['position']['y']),
        label: attribute['label'],
        type: AttributeType.values[attribute['type']],
      );
      diagramProvider.addElement(object);
    }

    for (final relationship in relationships) {
      final object = Relationship(
        id: relationship['id'],
        position: Offset(relationship['position']['x'], relationship['position']['y']),
        label: relationship['label'],
        type: RelationshipType.values[relationship['type']],
      );
      diagramProvider.addElement(object);
    }

    for (final connection in connections) {
      final startElement = diagramProvider.elements[connection['elements'][0]]!;
      final endElement = diagramProvider.elements[connection['elements'][1]]!;

      if (connection['cardinality'] != null) {
        final object = RelationshipConnection(
          id: connection['id'],
          elements: [startElement, endElement],
          cardinality: Cardinality.values[connection['cardinality']],
          optionality: Optionality.values[connection['optionality']],
          participation: Participation.values[connection['participation']],
          connectionPosition: ConnectionPosition.values[connection['connectionPosition']],
        );
        diagramProvider.addConnection(object);
      } else {
        final object = Connection(
          id: connection['id'],
          elements: [startElement, endElement],
        );
        diagramProvider.addConnection(object);
      }
    }

    return diagramProvider;
  }
}
