import 'package:flutter/widgets.dart';

class SizeProviderWidget extends StatefulWidget {
  const SizeProviderWidget({
    super.key,
    required this.child,
    required this.onSizeChanged,
  });

  final Widget child;
  final Function(Size size) onSizeChanged;

  @override
  SizeProviderWidgetState createState() => SizeProviderWidgetState();
}

class SizeProviderWidgetState extends State<SizeProviderWidget> {
  @override
  void initState() {
    _notify();
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return NotificationListener<SizeChangedLayoutNotification>(
      onNotification: (notification) {
        _notify();
        return true;
      },
      child: SizeChangedLayoutNotifier(
        child: widget.child,
      ),
    );
  }

  void _notify() {
    WidgetsBinding.instance.addPostFrameCallback((_) {
      final size = context.size;
      if (size is Size) {
        widget.onSizeChanged(size);
      }
    });
  }
}
