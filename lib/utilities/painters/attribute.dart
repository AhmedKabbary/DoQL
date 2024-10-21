import 'package:flutter/material.dart';

import '../../models/attribute.dart';
import '../path.dart';

class AttributePainter extends CustomPainter {
  AttributePainter({required this.type});

  final AttributeType type;

  @override
  void paint(Canvas canvas, Size size) {
    final backgroundPaint = Paint()
      ..color = Colors.white
      ..style = PaintingStyle.fill;

    canvas.drawOval(Rect.fromLTWH(0, 0, size.width, size.height), backgroundPaint);

    final borderPaint = Paint()
      ..color = Colors.black
      ..style = PaintingStyle.stroke
      ..strokeWidth = 1;

    switch (type) {
      case AttributeType.multivalued:
        canvas.drawOval(Rect.fromLTWH(0, 0, size.width, size.height), borderPaint);

        final innerBorderPaint = Paint()
          ..color = Colors.black
          ..style = PaintingStyle.stroke
          ..strokeWidth = 0.5;

        const double padding = 10;
        canvas.drawOval(
          Rect.fromCenter(
            center: Offset(size.width / 2, size.height / 2),
            width: size.width - padding,
            height: size.height - padding,
          ),
          innerBorderPaint,
        );
        break;

      case AttributeType.derived:
        final path = Path();
        path.addOval(Rect.fromLTWH(0, 0, size.width, size.height));

        final dashedPath = PathUtils.dashPath(
          path,
          dashArray: CircularIntervalList([5, 5]),
        );

        canvas.drawPath(dashedPath, borderPaint);
        break;

      default:
        canvas.drawOval(Rect.fromLTWH(0, 0, size.width, size.height), borderPaint);
    }
  }

  @override
  bool shouldRepaint(covariant AttributePainter oldDelegate) => oldDelegate.type != type;
}
