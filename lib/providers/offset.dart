import 'package:flutter/widgets.dart';

class OffsetProvider extends ChangeNotifier {
  Offset _offset = Offset.zero;

  Offset get offset => _offset;

  void move(Offset delta) {
    _offset += delta;
    notifyListeners();
  }
}
