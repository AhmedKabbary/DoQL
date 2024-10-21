import 'package:flutter/material.dart';

import '../../models/entity.dart';

class EntityPainter extends CustomPainter {
  EntityPainter({
    required this.type,
    required this.backgroundColor,
  });

  final EntityType type;
  final Color backgroundColor;

  @override
  void paint(Canvas canvas, Size size) {
    final backgroundPaint = Paint()
      ..color = Colors.teal
      ..style = PaintingStyle.fill;

    canvas.drawRect(Rect.fromLTWH(0, 0, size.width, size.height), backgroundPaint);

    if (type == EntityType.weak) {
      final innerBorderPaint = Paint()
        ..color = backgroundColor
        ..style = PaintingStyle.stroke
        ..strokeWidth = 3;

      const double padding = 6;
      canvas.drawRect(Rect.fromLTWH(padding, padding, size.width - (padding * 2), size.height - (padding * 2)), innerBorderPaint);
    } else if (type == EntityType.associative) {
      final path = Path()
        ..moveTo(0, size.height / 2)
        ..lineTo(size.width / 2, 0)
        ..lineTo(size.width, size.height / 2)
        ..lineTo(size.width / 2, size.height)
        ..close();

      final associationPaint = Paint()
        ..color = Colors.deepOrange
        ..style = PaintingStyle.fill;

      canvas.drawPath(path, associationPaint);
    }
  }

  @override
  bool shouldRepaint(covariant EntityPainter oldDelegate) => oldDelegate.type != type;
}
