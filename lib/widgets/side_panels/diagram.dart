import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../../providers/diagram.dart';
import '../../providers/pointer_mode.dart';
import '../../providers/scale.dart';
import '../../providers/theme.dart';
import '../../utilities/intents/add_element.dart';
import '../../utilities/intents/change_pointer_mode.dart';
import '../../utilities/intents/open_diagram.dart';
import '../../utilities/intents/save_diagram.dart';
import '../../utilities/intents/scale.dart';

class DiagramSidePanel extends StatelessWidget {
  const DiagramSidePanel({super.key});

  @override
  Widget build(BuildContext context) {
    return ListView(
      padding: const EdgeInsets.all(8),
      children: const [
        _DiagramActionsWidget(),
        Divider(),
        _ThemeSectionWidget(),
        Divider(),
        _PointerModeSectionWidget(),
        Divider(),
        _CreateElementsSectionWidget(),
        Divider(),
        _ScaleSectionWidget(),
      ],
    );
  }
}

class _DiagramActionsWidget extends StatelessWidget {
  const _DiagramActionsWidget();

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.symmetric(vertical: 16, horizontal: 8),
      child: Wrap(
        children: [
          TextButton.icon(
            label: const Text('Open'),
            icon: const Icon(Icons.file_open_rounded),
            onPressed: () => Actions.invoke(context, OpenDiagramIntent()),
          ),
          TextButton.icon(
            label: const Text('Save'),
            icon: const Icon(Icons.save_rounded),
            onPressed: () => Actions.invoke(context, SaveDiagramIntent()),
          ),
          TextButton.icon(
            label: const Text('Clear'),
            icon: const Icon(Icons.delete_sweep_rounded),
            onPressed: () {
              final diagramProvider = context.read<DiagramProvider>();
              diagramProvider.clear();
            },
          ),
        ],
      ),
    );
  }
}

class _ThemeSectionWidget extends StatelessWidget {
  const _ThemeSectionWidget();

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.symmetric(vertical: 8),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Padding(
            padding: const EdgeInsets.all(8),
            child: Text(
              'Theme',
              style: Theme.of(context).textTheme.titleMedium,
            ),
          ),
          Consumer<ThemeProvider>(
            builder: (context, themeProvider, _) {
              return Wrap(
                children: [
                  Padding(
                    padding: const EdgeInsets.all(8),
                    child: ChoiceChip(
                      label: const Text('System'),
                      selected: themeProvider.themeMode == ThemeMode.system,
                      onSelected: (_) {
                        themeProvider.setThemeMode(ThemeMode.system);
                      },
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.all(8),
                    child: ChoiceChip(
                      label: const Text('Light'),
                      selected: themeProvider.themeMode == ThemeMode.light,
                      onSelected: (_) {
                        themeProvider.setThemeMode(ThemeMode.light);
                      },
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.all(8),
                    child: ChoiceChip(
                      label: const Text('Dark'),
                      selected: themeProvider.themeMode == ThemeMode.dark,
                      onSelected: (_) {
                        themeProvider.setThemeMode(ThemeMode.dark);
                      },
                    ),
                  ),
                ],
              );
            },
          ),
        ],
      ),
    );
  }
}

class _PointerModeSectionWidget extends StatelessWidget {
  const _PointerModeSectionWidget();

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.symmetric(vertical: 8),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Padding(
            padding: const EdgeInsets.all(8),
            child: Text(
              'Pointer mode',
              style: Theme.of(context).textTheme.titleMedium,
            ),
          ),
          Consumer<PointerModeProvider>(
            builder: (context, pointerModeProvider, _) {
              return Wrap(
                children: [
                  Padding(
                    padding: const EdgeInsets.all(8),
                    child: ChoiceChip(
                      label: const Text('Select'),
                      selected: pointerModeProvider.mode == PointerMode.select,
                      onSelected: (_) {
                        Actions.invoke(context, const ChangePointerModeIntent(PointerMode.select));
                      },
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.all(8),
                    child: ChoiceChip(
                      label: const Text('Connect'),
                      selected: pointerModeProvider.mode == PointerMode.connect,
                      onSelected: (_) {
                        Actions.invoke(context, const ChangePointerModeIntent(PointerMode.connect));
                      },
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.all(8),
                    child: ChoiceChip(
                      label: const Text('Erase'),
                      selected: pointerModeProvider.mode == PointerMode.erase,
                      onSelected: (_) {
                        Actions.invoke(context, const ChangePointerModeIntent(PointerMode.erase));
                      },
                    ),
                  ),
                ],
              );
            },
          ),
        ],
      ),
    );
  }
}

class _CreateElementsSectionWidget extends StatelessWidget {
  const _CreateElementsSectionWidget();

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.symmetric(vertical: 8),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Padding(
            padding: const EdgeInsets.all(8),
            child: Text(
              'Create element',
              style: Theme.of(context).textTheme.titleMedium,
            ),
          ),
          Padding(
            padding: const EdgeInsets.all(8),
            child: Wrap(
              children: [
                TextButton(
                  child: const Text('Entity'),
                  onPressed: () => Actions.invoke(context, const AddEntityIntent()),
                ),
                TextButton(
                  child: const Text('Attribute'),
                  onPressed: () => Actions.invoke(context, const AddAttributeIntent()),
                ),
                TextButton(
                  child: const Text('Relationship'),
                  onPressed: () => Actions.invoke(context, const AddRelationshipIntent()),
                ),
              ],
            ),
          )
        ],
      ),
    );
  }
}

class _ScaleSectionWidget extends StatelessWidget {
  const _ScaleSectionWidget();

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.symmetric(vertical: 8),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Padding(
            padding: const EdgeInsets.all(8),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Text(
                  'Scale',
                  style: Theme.of(context).textTheme.titleMedium,
                ),
                Consumer<ScaleProvider>(
                  builder: (context, scaleProvider, _) {
                    final percentage = (scaleProvider.scaleFactor * 100).round();
                    return Text(
                      '$percentage%',
                      style: Theme.of(context).textTheme.bodySmall,
                    );
                  },
                ),
              ],
            ),
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            children: [
              Padding(
                padding: const EdgeInsets.all(8),
                child: OutlinedButton.icon(
                  label: const Text('Zoom in'),
                  icon: const Icon(Icons.zoom_in),
                  onPressed: () => Actions.invoke(context, const ScaleIntent(scaleFactor: 0.25)),
                ),
              ),
              Padding(
                padding: const EdgeInsets.all(8),
                child: OutlinedButton.icon(
                  label: const Text('Zoom out'),
                  icon: const Icon(Icons.zoom_out),
                  onPressed: () => Actions.invoke(context, const ScaleIntent(scaleFactor: -0.25)),
                ),
              ),
            ],
          ),
        ],
      ),
    );
  }
}
