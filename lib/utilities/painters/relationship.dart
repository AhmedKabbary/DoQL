import 'package:flutter/material.dart';

import '../../models/relationship.dart';

class RelationshipPainter extends CustomPainter {
  RelationshipPainter({
    required this.type,
    required this.backgroundColor,
  });

  final RelationshipType type;
  final Color backgroundColor;

  @override
  void paint(Canvas canvas, Size size) {
    final backgroundPaint = Paint()
      ..color = Colors.deepOrange
      ..style = PaintingStyle.fill;

    final path = Path()
      ..moveTo(0, size.height / 2)
      ..lineTo(size.width / 2, 0)
      ..lineTo(size.width, size.height / 2)
      ..lineTo(size.width / 2, size.height)
      ..close();

    canvas.drawPath(path, backgroundPaint);

    if (type == RelationshipType.weak) {
      final innerBorderPaint = Paint()
        ..color = backgroundColor
        ..style = PaintingStyle.stroke
        ..strokeWidth = 3;

      const double padding = 8;
      final nestedPath = Path()
        ..moveTo(padding, size.height / 2)
        ..lineTo(size.width / 2, padding)
        ..lineTo(size.width - padding, size.height / 2)
        ..lineTo(size.width / 2, size.height - padding)
        ..close();

      canvas.drawPath(nestedPath, innerBorderPaint);
    }
  }

  @override
  bool shouldRepaint(covariant RelationshipPainter oldDelegate) => oldDelegate.type != type;
}
