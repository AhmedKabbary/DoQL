import 'element.dart';

class Entity extends BaseDiagramElement {
  String label;
  EntityType type;

  Entity({
    required super.id,
    required super.position,
    required this.label,
    this.type = EntityType.strong,
  });
}

enum EntityType {
  strong,
  weak,
  associative,
}
