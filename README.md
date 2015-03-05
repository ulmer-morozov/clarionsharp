# clarionsharp
safe, 100% .net clarion reader with object mapping. Support Arrays!

This code read and map one record from Clarion .DAT database.

     const string filePath = "ANSW1.DAT";
      var bindingMap = new ClarionBindingMap<AnswersData>()
      .Map("NUM_REG", x => x.NumReg)
      .Map("NUM_TEST", x => x.NumTest)
      .Map("QUEST", x => x.QuestionCount)
      .Map("NUM_Q", x => x.Numbers)
      .Map("ANSWER", x => x.Answers);
      var file = new ClarionDatabase(filePath);
      var result = file.ReadRecord(bindingMap);

# License
Apache License 2.0