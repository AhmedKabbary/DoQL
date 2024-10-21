import 'package:flutter/widgets.dart';
import 'package:provider/provider.dart';

import '../../providers/active_element.dart';
import '../../providers/diagram.dart';
import '../intents/delete_element.dart';

class DeleteActiveElementAction extends ContextAction<DeleteActiveElementIntent> {
  @override
  Object? invoke(DeleteActiveElementIntent intent, [BuildContext? context]) {
    if (context == null) {
      return null;
    }

    final diagramProvider = context.read<DiagramProvider>();
    final activeElementProvider = context.read<ActiveElementProvider>();

    if (activeElementProvider.activeElement != null) {
      diagramProvider.deleteElement(activeElementProvider.activeElement!.id);
    }

    return null;
  }
}
