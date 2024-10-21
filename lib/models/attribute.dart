import 'element.dart';

class Attribute extends BaseDiagramElement {
  String label;
  AttributeType type;

  Attribute({
    required super.id,
    required super.position,
    required this.label,
    this.type = AttributeType.normal,
  });
}

enum AttributeType {
  normal,
  key,
  partialKey,
  multivalued,
  derived,
  composite,
}
