import 'package:flutter/widgets.dart';

class BaseDiagramElement {
  String id;
  Offset position;
  Size? size;

  BaseDiagramElement({
    required this.id,
    required this.position,
  });
}
