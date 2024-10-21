import 'dart:ui';

import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../../models/element.dart';
import '../../providers/offset.dart';
import '../../providers/pointer_mode.dart';
import '../../providers/active_element.dart';
import '../../providers/pseudo_connection.dart';
import '../../utilities/intents/delete_element.dart';
import '../utilities/size_provider.dart';

class ErdSymbol extends StatefulWidget {
  const ErdSymbol({
    super.key,
    this.onMove,
    this.clipper,
    this.painter,
    required this.child,
    required this.element,
    required this.onConnection,
  });

  final Widget child;
  final Function onConnection;
  final CustomPainter? painter;
  final BaseDiagramElement element;
  final CustomClipper<Path>? clipper;
  final Function(DragUpdateDetails details)? onMove;

  @override
  State<ErdSymbol> createState() => _ErdSymbolState();
}

class _ErdSymbolState extends State<ErdSymbol> {
  Offset localOffset = Offset.zero;

  @override
  Widget build(BuildContext context) {
    final offsetProvider = context.read<OffsetProvider>();
    final pseudoConnection = context.read<PseudoConnection>();
    final pointerModeProvider = context.read<PointerModeProvider>();
    final activeElementProvider = context.read<ActiveElementProvider>();

    return Positioned(
      top: offsetProvider.offset.dy + widget.element.position.dy,
      left: offsetProvider.offset.dx + widget.element.position.dx,
      child: Focus(
        onFocusChange: (value) {
          if (value) {
            activeElementProvider.setActiveElement(widget.element);
          }
        },
        child: Builder(
          builder: (context) {
            return ClipPath(
              clipper: widget.clipper,
              child: GestureDetector(
                supportedDevices: PointerDeviceKind.values.toSet()..remove(PointerDeviceKind.trackpad),
                onTap: () {
                  Focus.of(context).requestFocus();

                  if (pointerModeProvider.mode == PointerMode.connect) {
                    if (pseudoConnection.isActive) {
                      widget.onConnection();
                      pseudoConnection.cancel();
                    } else {
                      pseudoConnection.setStartingElement(widget.element);
                    }
                  }

                  if (pointerModeProvider.mode == PointerMode.erase) {
                    Actions.invoke(context, DeleteActiveElementIntent());
                  }
                },
                onSecondaryTap: () {
                  Focus.of(context).requestFocus();

                  final RenderBox renderBox = context.findRenderObject() as RenderBox;
                  final offset = renderBox.localToGlobal(localOffset);

                  showMenu(
                    context: context,
                    position: RelativeRect.fromLTRB(
                      offset.dx,
                      offset.dy,
                      MediaQuery.of(context).size.width - offset.dx,
                      MediaQuery.of(context).size.height - offset.dy,
                    ),
                    items: [
                      PopupMenuItem(
                        child: const Text('Delete'),
                        onTap: () => Actions.invoke(context, DeleteActiveElementIntent()),
                      ),
                    ],
                  );
                },
                onPanUpdate: (details) {
                  if (pointerModeProvider.mode == PointerMode.select) {
                    widget.onMove?.call(details);
                  }
                },
                child: MouseRegion(
                  cursor: SystemMouseCursors.click,
                  onHover: (event) {
                    localOffset = event.localPosition;
                  },
                  child: CustomPaint(
                    painter: widget.painter,
                    child: SizeProviderWidget(
                      onSizeChanged: (size) {
                        widget.element.size = size;
                      },
                      child: widget.child,
                    ),
                  ),
                ),
              ),
            );
          },
        ),
      ),
    );
  }
}
