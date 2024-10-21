import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import 'pages/diagram.dart';
import 'providers/theme.dart';

void main() {
  runApp(const MainApp());
}

class MainApp extends StatelessWidget {
  const MainApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MultiProvider(
      providers: [
        ChangeNotifierProvider(create: (_) => ThemeProvider()),
      ],
      child: const MyApp(),
    );
  }
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      themeMode: context.watch<ThemeProvider>().themeMode,
      theme: ThemeData.light(),
      darkTheme: ThemeData.dark(),
      home: const DiagramPage(),
    );
  }
}
