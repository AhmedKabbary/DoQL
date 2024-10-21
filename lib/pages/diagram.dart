import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:provider/provider.dart';

import '../providers/scale.dart';
import '../providers/offset.dart';
import '../providers/diagram.dart';
import '../providers/pointer_mode.dart';
import '../providers/active_element.dart';
import '../providers/pseudo_connection.dart';
import '../utilities/actions/scale.dart';
import '../utilities/actions/add_element.dart';
import '../utilities/actions/move_element.dart';
import '../utilities/actions/open_diagram.dart';
import '../utilities/actions/save_diagram.dart';
import '../utilities/actions/add_connection.dart';
import '../utilities/actions/delete_element.dart';
import '../utilities/actions/change_pointer_mode.dart';
import '../utilities/intents/scale.dart';
import '../utilities/intents/add_element.dart';
import '../utilities/intents/move_element.dart';
import '../utilities/intents/open_diagram.dart';
import '../utilities/intents/save_diagram.dart';
import '../utilities/intents/add_connection.dart';
import '../utilities/intents/delete_element.dart';
import '../utilities/intents/change_pointer_mode.dart';
import '../widgets/diagram_panel.dart';
import '../widgets/side_panel.dart';

class DiagramPage extends StatelessWidget {
  const DiagramPage({super.key});

  @override
  Widget build(BuildContext context) {
    return MultiProvider(
      providers: [
        ChangeNotifierProvider(create: (_) => ActiveElementProvider()),
        ChangeNotifierProvider(create: (_) => PointerModeProvider()),
        ChangeNotifierProvider(create: (_) => PseudoConnection()),
        ChangeNotifierProvider(create: (_) => DiagramProvider()),
        ChangeNotifierProvider(create: (_) => OffsetProvider()),
        ChangeNotifierProvider(create: (_) => ScaleProvider()),
      ],
      child: Actions(
        actions: {
          OpenDiagramIntent: OpenDiagramAction(),
          SaveDiagramIntent: SaveDiagramAction(),
          AddEntityIntent: AddEntityAction(),
          AddAttributeIntent: AddAttributeAction(),
          AddRelationshipIntent: AddRelationshipAction(),
          AddConnectionIntent: AddConnectionAction(),
          MoveElementIntent: MoveElementAction(),
          DeleteActiveElementIntent: DeleteActiveElementAction(),
          ChangePointerModeIntent: ChangePointerModeAction(),
          ScaleIntent: ScaleAction(),
        },
        child: const _DiagramPageBody(),
      ),
    );
  }
}

class _DiagramPageBody extends StatelessWidget {
  const _DiagramPageBody();

  @override
  Widget build(BuildContext context) {
    return Shortcuts(
      shortcuts: {
        const SingleActivator(LogicalKeyboardKey.keyS, control: true): SaveDiagramIntent(),
        const SingleActivator(LogicalKeyboardKey.keyO, control: true): OpenDiagramIntent(),
      },
      child: Scaffold(
        body: LayoutBuilder(
          builder: (context, constraints) {
            if (constraints.maxWidth > 768) {
              return const Row(
                children: [
                  Expanded(child: DiagramPanel()),
                  SidePanel(),
                ],
              );
            } else {
              return const DiagramPanel();
            }
          },
        ),
      ),
    );
  }
}
