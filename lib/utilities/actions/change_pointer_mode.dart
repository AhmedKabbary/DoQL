import 'package:flutter/widgets.dart';
import 'package:provider/provider.dart';

import '../intents/change_pointer_mode.dart';
import '../../providers/pointer_mode.dart';

class ChangePointerModeAction extends ContextAction<ChangePointerModeIntent> {
  @override
  Object? invoke(ChangePointerModeIntent intent, [BuildContext? context]) {
    if (context == null) {
      return null;
    }

    final pointerModeProvider = context.read<PointerModeProvider>();
    pointerModeProvider.setPointerMode(intent.mode);
    return null;
  }
}
