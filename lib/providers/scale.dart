import 'package:flutter/foundation.dart';

class ScaleProvider extends ChangeNotifier {
  double _scaleFactor = 1;

  double get scaleFactor => _scaleFactor;

  void scale(double delta) {
    if (scaleFactor + delta > 0) {
      _scaleFactor += delta;
      notifyListeners();
    }
  }
}
