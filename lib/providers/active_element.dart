import 'package:flutter/material.dart';

import '../models/element.dart';

class ActiveElementProvider extends ChangeNotifier {
  BaseDiagramElement? _activeElement;

  BaseDiagramElement? get activeElement => _activeElement;

  void setActiveElement(BaseDiagramElement element) {
    _activeElement = element;
    notifyListeners();
  }

  void reset() {
    _activeElement = null;
    notifyListeners();
  }
}
