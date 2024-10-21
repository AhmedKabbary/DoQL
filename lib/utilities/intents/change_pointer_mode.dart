import 'package:flutter/widgets.dart';

import '../../providers/pointer_mode.dart';

class ChangePointerModeIntent extends Intent {
  const ChangePointerModeIntent(this.mode);

  final PointerMode mode;
}
