import 'package:flutter/widgets.dart';

class AddEntityIntent extends Intent {
  const AddEntityIntent({this.position});

  final Offset? position;
}

class AddAttributeIntent extends Intent {
  const AddAttributeIntent({this.position});

  final Offset? position;
}

class AddRelationshipIntent extends Intent {
  const AddRelationshipIntent({this.position});

  final Offset? position;
}
