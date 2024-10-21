import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:provider/provider.dart';

import '../providers/scale.dart';
import '../providers/offset.dart';
import '../providers/diagram.dart';
import '../providers/pointer_mode.dart';
import '../providers/active_element.dart';
import '../providers/pseudo_connection.dart';
import '../utilities/painters/connections.dart';
import '../utilities/diagram_widgets_factory.dart';
import '../utilities/intents/scale.dart';
import '../utilities/intents/add_element.dart';
import '../utilities/intents/delete_element.dart';
import '../utilities/intents/change_pointer_mode.dart';
import 'utilities/size_provider.dart';

class DiagramPanel extends StatelessWidget {
  const DiagramPanel({super.key});

  @override
  Widget build(BuildContext context) {
    return Shortcuts(
      shortcuts: {
        const SingleActivator(LogicalKeyboardKey.keyE): const AddEntityIntent(),
        const SingleActivator(LogicalKeyboardKey.keyA): const AddAttributeIntent(),
        const SingleActivator(LogicalKeyboardKey.keyR): const AddRelationshipIntent(),
        const SingleActivator(LogicalKeyboardKey.delete): DeleteActiveElementIntent(),
        const SingleActivator(LogicalKeyboardKey.numpadAdd, control: true): const ScaleIntent(scaleFactor: 0.25),
        const SingleActivator(LogicalKeyboardKey.numpadSubtract, control: true): const ScaleIntent(scaleFactor: -0.25),
        const SingleActivator(LogicalKeyboardKey.keyS, alt: true): const ChangePointerModeIntent(PointerMode.select),
        const SingleActivator(LogicalKeyboardKey.keyC, alt: true): const ChangePointerModeIntent(PointerMode.connect),
        const SingleActivator(LogicalKeyboardKey.keyE, alt: true): const ChangePointerModeIntent(PointerMode.erase),
      },
      child: const _DiagramPanelBody(),
    );
  }
}

class _DiagramPanelBody extends StatelessWidget {
  const _DiagramPanelBody();

  @override
  Widget build(BuildContext context) {
    final scaleProvider = context.read<ScaleProvider>();
    final offsetProvider = context.read<OffsetProvider>();
    final diagramProvider = context.read<DiagramProvider>();
    final pseudoConnection = context.read<PseudoConnection>();
    final activeElementProvider = context.read<ActiveElementProvider>();

    return FocusScope(
      autofocus: true,
      child: ColoredBox(
        color: Theme.of(context).colorScheme.surface,
        child: GestureDetector(
          onTap: () => _onTap(context, pseudoConnection, activeElementProvider),
          onSecondaryTap: () => _onSecondaryTap(context, pseudoConnection),
          onPanUpdate: (details) => offsetProvider.move(details.delta / scaleProvider.scaleFactor),
          child: MouseRegion(
            onHover: (event) => pseudoConnection.updateCurrentLocation(event.localPosition),
            child: SizeProviderWidget(
              onSizeChanged: (size) => diagramProvider.setDiagramSize(size),
              child: ClipRect(
                child: Consumer<ScaleProvider>(
                  child: const _Diagram(),
                  builder: (context, scaleProvider, child) {
                    return Transform.scale(
                      scale: scaleProvider.scaleFactor,
                      child: child,
                    );
                  },
                ),
              ),
            ),
          ),
        ),
      ),
    );
  }

  void _onTap(BuildContext context, PseudoConnection pseudoConnection, ActiveElementProvider activeElementProvider) {
    if (pseudoConnection.isActive) {
      pseudoConnection.cancel();
    }
    activeElementProvider.reset();
    Focus.of(context).requestFocus(FocusNode()..attach(context));
  }

  void _onSecondaryTap(BuildContext context, PseudoConnection pseudoConnection) {
    final RenderBox renderBox = context.findRenderObject() as RenderBox;
    final globalOffset = renderBox.localToGlobal(pseudoConnection.currentLocation);
    showMenu(
      context: context,
      position: RelativeRect.fromLTRB(
        globalOffset.dx,
        globalOffset.dy,
        MediaQuery.of(context).size.width - globalOffset.dx,
        MediaQuery.of(context).size.height - globalOffset.dy,
      ),
      items: [
        PopupMenuItem(
          child: const Text('Add Entity'),
          onTap: () => Actions.invoke(context, AddEntityIntent(position: pseudoConnection.currentLocation)),
        ),
        PopupMenuItem(
          child: const Text('Add Attribute'),
          onTap: () => Actions.invoke(context, AddAttributeIntent(position: pseudoConnection.currentLocation)),
        ),
        PopupMenuItem(
          child: const Text('Add Relationship'),
          onTap: () => Actions.invoke(context, AddRelationshipIntent(position: pseudoConnection.currentLocation)),
        ),
      ],
    );
  }
}

class _Diagram extends StatelessWidget {
  const _Diagram();

  @override
  Widget build(BuildContext context) {
    final offsetProvider = context.watch<OffsetProvider>();
    final diagramProvider = context.watch<DiagramProvider>();
    final pseudoConnection = context.watch<PseudoConnection>();

    return CustomPaint(
      willChange: true,
      painter: ConnectionsPainter(
        offset: offsetProvider.offset,
        pseudoConnection: pseudoConnection,
        connections: diagramProvider.connections.toList(),
        color: Theme.of(context).colorScheme.onSurface,
        backgroundColor: Theme.of(context).colorScheme.surface,
      ),
      child: Stack(
        clipBehavior: Clip.none,
        children: diagramProvider.elements.values.map((e) => DiagramElementWidgetFactory.map(e)).toList(),
      ),
    );
  }
}
