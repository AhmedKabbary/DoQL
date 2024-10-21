import 'dart:ui';

class PathUtils {
  static Path dashPath(Path source, {required CircularIntervalList<double> dashArray}) {
    final dashedPath = Path();
    for (final metric in source.computeMetrics()) {
      bool draw = true;
      double distance = 0;
      while (distance < metric.length) {
        final len = dashArray.next;
        if (draw) {
          dashedPath.addPath(metric.extractPath(distance, distance + len), Offset.zero);
        }
        distance += len;
        draw = !draw;
      }
    }
    return dashedPath;
  }
}

class CircularIntervalList<T> {
  CircularIntervalList(this._values);

  int _index = 0;
  final List<T> _values;

  T get next {
    if (_index >= _values.length) {
      _index = 0;
    }
    return _values[_index++];
  }
}
