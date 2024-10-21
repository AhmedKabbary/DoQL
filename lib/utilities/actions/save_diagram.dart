import 'dart:io';

import 'package:file_picker/file_picker.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/widgets.dart';
import 'package:provider/provider.dart';
import 'package:file_saver/file_saver.dart';

import '../../providers/diagram.dart';
import '../../services/storage.dart';
import '../intents/save_diagram.dart';

class SaveDiagramAction extends ContextAction<SaveDiagramIntent> {
  @override
  Future<Object?> invoke(SaveDiagramIntent intent, [BuildContext? context]) async {
    if (context == null) {
      return null;
    }

    final diagramProvider = context.read<DiagramProvider>();
    final bytes = StorageService.encode(diagramProvider);

    if (kIsWeb) {
      await FileSaver.instance.saveFile(
        name: 'erd',
        ext: '.json',
        bytes: bytes,
        mimeType: MimeType.json,
      );
    } else {
      final path = await FilePicker.platform.saveFile(
        lockParentWindow: true,
        fileName: 'erd.json',
      );
      if (path != null) {
        await File(path).writeAsBytes(bytes);
      }
    }

    return null;
  }
}
