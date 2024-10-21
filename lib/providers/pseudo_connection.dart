import 'package:flutter/material.dart';

import '../models/element.dart';

class PseudoConnection extends ChangeNotifier {
  BaseDiagramElement? _startElement;
  Offset _currentLocation = Offset.zero;

  BaseDiagramElement? get startElement => _startElement;
  Offset get currentLocation => _currentLocation;
  bool get isActive => _startElement != null;

  void setStartingElement(BaseDiagramElement startingElement) {
    _startElement = startingElement;
    notifyListeners();
  }

  void updateCurrentLocation(Offset location) {
    _currentLocation = location;
    if (isActive) {
      notifyListeners();
    }
  }

  void cancel() {
    _startElement = null;
    notifyListeners();
  }
}
