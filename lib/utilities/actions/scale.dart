import 'package:flutter/widgets.dart';
import 'package:provider/provider.dart';

import '../../providers/scale.dart';
import '../intents/scale.dart';

class ScaleAction extends ContextAction<ScaleIntent> {
  @override
  Object? invoke(ScaleIntent intent, [BuildContext? context]) {
    if (context == null) {
      return null;
    }

    final scaleProvider = context.read<ScaleProvider>();

    scaleProvider.scale(intent.scaleFactor);

    return null;
  }
}
