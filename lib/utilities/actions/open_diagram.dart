import 'package:flutter/widgets.dart';
import 'package:provider/provider.dart';
import 'package:file_picker/file_picker.dart';

import '../../providers/diagram.dart';
import '../../services/storage.dart';
import '../intents/open_diagram.dart';

class OpenDiagramAction extends ContextAction<OpenDiagramIntent> {
  @override
  Future<Object?> invoke(OpenDiagramIntent intent, [BuildContext? context]) async {
    if (context == null) {
      return null;
    }

    final diagramProvider = context.read<DiagramProvider>();

    FilePickerResult? result = await FilePicker.platform.pickFiles(
      lockParentWindow: true,
      withData: true,
    );

    if (result != null && result.files.isNotEmpty) {
      final bytes = result.files.single.bytes;
      if (bytes != null) {
        final loadedDiagram = StorageService.decode(bytes);

        diagramProvider.clear();

        for (var element in loadedDiagram.elements.values) {
          diagramProvider.addElement(element);
        }

        for (var connection in loadedDiagram.connections) {
          diagramProvider.addConnection(connection);
        }

        // This is a hack to redraw connections after element sizes are obtained
        WidgetsBinding.instance.addPostFrameCallback((_) => diagramProvider.refresh());
      }
    }

    return null;
  }
}
