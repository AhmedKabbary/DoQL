import 'package:flutter/material.dart';

import '../models/attribute.dart';
import '../models/entity.dart';
import '../models/relationship.dart';
import '../models/element.dart';
import '../widgets/symbols/attribute.dart';
import '../widgets/symbols/entity.dart';
import '../widgets/symbols/relationship.dart';

class DiagramElementWidgetFactory {
  static Widget map(BaseDiagramElement element) {
    return switch (element) {
      Entity element => EntitySymbol(entity: element),
      Attribute element => AttributeSymbol(attribute: element),
      Relationship element => RelationshipSymbol(relationship: element),
      _ => throw UnsupportedError('Unsupported element type: ${element.runtimeType}'),
    };
  }
}
