import 'dart:collection';

import 'package:flutter/widgets.dart';

import '../models/connection.dart';
import '../models/element.dart';

class DiagramProvider extends ChangeNotifier {
  final elements = <String, BaseDiagramElement>{};
  final connections = HashSet<Connection>();

  // Diagram size

  Size _diagramSize = const Size(0, 0);
  Size get diagramSize => _diagramSize;
  void setDiagramSize(Size size) {
    _diagramSize = size;
    notifyListeners();
  }

  // Elements methods

  BaseDiagramElement? getElement(String id) {
    return elements[id];
  }

  void addElement(BaseDiagramElement element) {
    elements.putIfAbsent(element.id, () => element);
    notifyListeners();
  }

  void updateElement(BaseDiagramElement element) {
    notifyListeners();
  }

  void deleteElement(String id) {
    final connections = getElementConnections(id);
    for (var connection in connections) {
      deleteConnection(connection.id);
    }
    elements.remove(id);
    notifyListeners();
  }

  // Connections methods

  List<Connection> getElementConnections(String id) {
    return connections.where((connection) => connection.elements.any((element) => element.id == id)).toList();
  }

  void addConnection(Connection connection, {bool ifNotExist = true}) {
    if (ifNotExist) {
      final bool exists = connections.any((e) => e.elements.every((element) => connection.elements.contains(element)));
      if (exists) {
        return;
      }
    }
    connections.add(connection);
    notifyListeners();
  }

  void updateConnection(Connection connection) {
    notifyListeners();
  }

  void deleteConnection(String id) {
    connections.removeWhere((connection) => connection.id == id);
    notifyListeners();
  }

  // Other methods

  void clear() {
    elements.clear();
    connections.clear();
    notifyListeners();
  }

  void refresh() => notifyListeners();
}
