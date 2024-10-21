import 'package:flutter/widgets.dart';

import '../../models/element.dart';

class MoveElementIntent extends Intent {
  const MoveElementIntent({
    required this.element,
    required this.delta,
  });

  final BaseDiagramElement element;
  final Offset delta;
}
