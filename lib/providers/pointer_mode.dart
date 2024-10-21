import 'package:flutter/foundation.dart';

class PointerModeProvider extends ChangeNotifier {
  PointerMode _mode = PointerMode.select;

  PointerMode get mode => _mode;

  void setPointerMode(PointerMode mode) {
    _mode = mode;
    notifyListeners();
  }
}

enum PointerMode {
  select,
  connect,
  erase,
}
