import 'package:flutter/widgets.dart';

import '../../models/element.dart';

class AddConnectionIntent extends Intent {
  const AddConnectionIntent({required this.elements});

  final List<BaseDiagramElement> elements;
}
