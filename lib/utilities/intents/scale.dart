import 'package:flutter/widgets.dart';

class ScaleIntent extends Intent {
  const ScaleIntent({required this.scaleFactor});

  final double scaleFactor;
}
