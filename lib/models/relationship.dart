import 'element.dart';

class Relationship extends BaseDiagramElement {
  String label;
  RelationshipType type;

  Relationship({
    required super.id,
    required super.position,
    required this.label,
    this.type = RelationshipType.strong,
  });
}

enum RelationshipType {
  strong,
  weak,
}
