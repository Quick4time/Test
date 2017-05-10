using UnityEditor;
using UnityEngine;
using UnityEditor.Callbacks;

public class TestPostBuild : MonoBehaviour {
    
    [PostProcessBuild]
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {
        Debug.Log("built location: " + pathToBuiltProject);
    }
}
/*
Базовый процесс построения превосходно подходит для большинства ситуаций, 
но некоторые предпочитают при построении каждой игры совершать дополнительные действия (например, перемещать справочные файлы в папку, в которой находится приложение). 
Такие задачи можно легко автоматизировать, поместив их в сценарий, запускаемый после завершения процесса сборки.
Первым делом создайте новую папку на вкладке Project и присвойте ей имя Editor; 
именно здесь должны находиться все сценарии, влияющие на редактор Unity (это касается и процесса сборки). 
Создайте в этой папке сценарий с именем TestPostBuild и введите в него следующий код:
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
public static class TestPostBuild {
[PostProcessBuild]
public static void OnPostprocessBuild(BuildTarget target, string
pathToBuiltProject) {
Debug.Log("build location: " + pathToBuiltProject);
}
}
Директива [PostProcessBuild] заставляет сценарий запускать расположенную непосредственно за ней функцию. 
Эта функция получит местоположение построенного приложения; после этого вы сможете использовать данный параметр в различных командах для работы с файловой системой из языка C#. 
В настоящее время путь к файлу выводится на консоль, что позволяет удостовериться в работоспособности сценария.
Приложение появится в указанной вами папке; запустите его двойным щелчком, как любую другую программу. Мои поздравления! Как видите, это было несложно. 
Процесс построения приложений совершенно тривиален, но допускает различные варианты настройки; посмотрим, как мы можем его доработать.
*/

