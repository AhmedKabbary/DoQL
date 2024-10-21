import 'package:flutter/material.dart';

import '../../models/connection.dart';
import '../../providers/pseudo_connection.dart';
import '../../models/relationship.dart';
import '../path.dart';

class ConnectionsPainter extends CustomPainter {
  ConnectionsPainter({
    required this.color,
    required this.offset,
    required this.connections,
    required this.backgroundColor,
    required this.pseudoConnection,
  });

  final Color color;
  final Offset offset;
  final Color backgroundColor;
  final List<Connection> connections;
  final PseudoConnection pseudoConnection;

  @override
  void paint(Canvas canvas, Size size) {
    final paint = Paint()
      ..color = color
      ..strokeWidth = 1
      ..style = PaintingStyle.stroke;

    // pseudo connection
    if (pseudoConnection.startElement != null && pseudoConnection.startElement?.size != null) {
      final p1 = pseudoConnection.startElement!.size!.center(pseudoConnection.startElement!.position + offset);
      final p2 = pseudoConnection.currentLocation;
      canvas.drawLine(p1, p2, paint);
    }

    // connections
    for (var connection in connections) {
      if (connection.elements.any((element) => element.size == null)) continue;

      final p1 = connection.elements[0].size!.center(connection.elements[0].position + offset);
      final p2 = connection.elements[1].size!.center(connection.elements[1].position + offset);
      final points = [p1, p2];

      // normal connection
      if (connection is! RelationshipConnection) {
        canvas.drawLine(points[0], points[1], paint);
        continue;
      }

      // relationship connection

      for (int i = 0; i < connection.elements.length; i++) {
        final element = connection.elements[i];

        if (element is Relationship) {
          Offset newOffset;

          switch (connection.connectionPosition) {
            case ConnectionPosition.top:
              newOffset = element.size!.topCenter(element.position + offset + const Offset(0, 5));
              break;
            case ConnectionPosition.left:
              newOffset = element.size!.centerLeft(element.position + offset + const Offset(5, 0));
              break;
            case ConnectionPosition.right:
              newOffset = element.size!.centerRight(element.position + offset + const Offset(-5, 0));
              break;
            case ConnectionPosition.bottom:
              newOffset = element.size!.bottomCenter(element.position + offset + const Offset(0, -5));
              break;
          }

          points[i] = newOffset;
        }
      }

      if (connection.participation == Participation.total) {
        final bottomPaint = Paint()
          ..style = PaintingStyle.stroke
          ..strokeWidth = 7
          ..color = color;

        final topPaint = Paint()
          ..style = PaintingStyle.stroke
          ..color = backgroundColor
          ..strokeWidth = 5;

        Path bottomPath = Path()
          ..moveTo(points[0].dx, points[0].dy)
          ..lineTo(points[1].dx, points[1].dy);

        if (connection.optionality == Optionality.optional) {
          bottomPath = PathUtils.dashPath(bottomPath, dashArray: CircularIntervalList([5, 5]));
        }

        canvas.drawPath(bottomPath, bottomPaint);
        canvas.drawLine(points[0], points[1], topPaint);
      } else {
        Path path = Path()
          ..moveTo(points[0].dx, points[0].dy)
          ..lineTo(points[1].dx, points[1].dy);

        if (connection.optionality == Optionality.optional) {
          path = PathUtils.dashPath(path, dashArray: CircularIntervalList([5, 5]));
        }

        canvas.drawPath(path, paint);
      }

      // draw cardinality
      final center = (points[0] + points[1]) / 2;
      final textPainter = TextPainter(
        text: TextSpan(
          text: connection.cardinality == Cardinality.many ? 'M' : '1',
          style: TextStyle(
            color: color,
            backgroundColor: backgroundColor,
          ),
        ),
        textDirection: TextDirection.ltr,
      );
      textPainter.layout();
      textPainter.paint(canvas, center - Offset(textPainter.width / 2, textPainter.height / 2));
    }
  }

  @override
  bool shouldRepaint(covariant CustomPainter oldDelegate) => true;
}
