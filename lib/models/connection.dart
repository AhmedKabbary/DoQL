import 'element.dart';

class Connection {
  final String id;
  final List<BaseDiagramElement> elements;

  Connection({
    required this.id,
    required this.elements,
  });
}

class RelationshipConnection extends Connection {
  Cardinality cardinality;
  Optionality optionality;
  Participation participation;
  ConnectionPosition connectionPosition;

  RelationshipConnection({
    required super.id,
    required super.elements,
    this.cardinality = Cardinality.one,
    this.optionality = Optionality.mandatory,
    this.participation = Participation.partial,
    this.connectionPosition = ConnectionPosition.left,
  });
}

enum Cardinality { one, many }

enum Optionality { mandatory, optional }

enum Participation { total, partial }

enum ConnectionPosition { top, left, right, bottom }
