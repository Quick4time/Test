using UnityEngine;
using System.Collections;
using System.Collections.Generic;

#region Оптимизация стр 119.ЗВУК!!!! Метод загрузки выбранного файла.
///<summary>
/// Decompress On Load (Распаковать при загрузке), аудиофайл, хранящийся на диске в сжатом виде для экономии места, будет распакован при загрузке в память. Это стандартный метод загрузки
/// аудиофайлов, и в большенстве случаем именно он должен применяться.
/// ------------------------------------------
/// Compressed In Memory (Хранить в памяти в сжатом виде), сжатый файл загрузить в память без обработки и будет распаковываться непосредственно при воспроизведении. Здесь за счет 
/// увелечения потребления центрального процессора при воспроизведении увеличивается скорость загрузки клипа и уменьшается потребления памяти во время выполнения. Этот вариант
/// лучше подходит для больших и часто используемых аудиофайлов, или если потребление памяти жестко ограничено, но можно пожертвовать некоторым временем центрального процессора для
/// воспроизведения аудиоклипа.
/// ------------------------------------------
/// Streaminu (Потоковая передача), файлы будут загружаться, декодироваться и воспроизводиться "на лету" с использованием небольшого буфера. Этот метод имеет минимальное потребление памяти для отдельных
/// аудиоклипов и больше всего нагружает центральный процессор. к сожалению, он не позволяет сослаться на тот же буфер повторно. Попытка запустить несколько потоков воспроизведения одного и того же 
/// аудиоклипа приведет к выделению в памяти нового буфера для каждого потока, что при бездумном применении этого метода приведет к значительному потреблению оперативной памяти и ресурсов центрального 
/// процессора. Как следствие этот вариант лучше подходит для регулярного воспроизведения единственного экземпляра аудиоклипа, который никогда не пересекается с другими экземплярами. То есть этот 
/// параметр следует использовать для воспроизведения фоновой музыки или звуковых эффектов, звучащих большую часть времени в сцене.
///</summary>
#endregion

#region Оптимизация стр 122.ЗВУК!!! Compression Format (Формат Сжатия)
/// <summary>
/// Формат PCM не предусматривает сжатия. лишен искажений и обиспечивает качество, близкое к качеству аналогового аудио.
/// Он характеризуется большим размером файлов и наивысшим качеством звука.Его рекомендуеться использовать для очень коротких звуковых эффектов, требующих высокой четкости, недостижимой при применении сжатия.
/// ------------------------------------------
/// Формат ADPCM более эффективно использует память и ресурсы центрального процессора, чем PCM, но сжатие привносит изрядное количество шумов. Эти шумы незаметны в коротких звуковых эффектах, 
/// хаоса, подобных звукам взрывов, столкновений и ударов, где посторонние шумы не являются критичными.
/// ------------------------------------------
/// Формат Compressed позволяет уменьшить размероы файлов и получить качество звучения хуже, чем при использовании формата PCM, но лучше, чем при использовании формата ADPCM за счет дополнительного
/// использования ресурсов центрального процессора. Этот формат рекомендован к приминению в большенстве случаев. При выборе этого варианта появляется возможность настроить уровень качества алгоритма сжатия и достичь
/// нужного баланса между качеством и размером файла. 
/// </summary>
#endregion

#region Требование к спрайтам
///<summary>
/// Спрайты должны быть квадратной, но могут быть и прямоугольной (не желательно) и не равными одной из степени числа 2.
/// 22 = 4 (Второе число в 22 это степень)
/// 23 = 8
/// 24 = 16
/// 25 = 32
/// 26 = 64
/// 27 = 128
/// 28 = 256
/// 29 = 512
/// 210 = 1024
///</summary>
#endregion
/*
public class AudioSystem : SingletonAsComponent<AudioSystem>
{
    // 125 page.Optimization.
    [SerializeField]
    AudioSource _source;

    AudioClip _loadedResource;
    
    public static AudioSystem Instance
    {
        get { return ((AudioSystem)_Instance); }
        set { _Instance = value; }
    }
    public void PlaySound(string resourceName)
    {
        _loadedResource = Resources.Load(resourceName) as AudioClip;
        _source.PlayOneShot(_loadedResource);
    } 
    
	void Update ()
    {
	    if(!_source.isPlaying && _loadedResource != null)
        {
            Resources.UnloadAsset(_loadedResource);
            _loadedResource = null;
        }
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
*/
// Note: This approach loads the AudioClip using Resources.Load() dynamically.
// Once the resource is no longer needed (the audio clip has stopped playing), the
// resource is freed from memory via (Resources.UnloadAsset()), reducing runtime
// memory consumption

// this system can be extended to support multiple audio sources, and audio clips playing
// simultaneously (this is how a lot of Audio assets on the Asset Store manage resources)

public class AudioSystem : SingletonAsComponent<AudioSystem>
{

    [SerializeField]
    AudioSource _source;

    AudioClip _loadedResource;

    // NOTE: Because this SingletonAsComponent needs outside references (an AudioSource)
    // it must exist in the Scene prior to startup. Hence, the ShouldBeSetToDontDestroyOnLoadDuringAwake
    // method is overridden to ensure it remains if another scene is loaded
    protected override bool ShouldBeSetToDontDestroyOnLoadDuringAwake()
    {
        return true;
    }

    public static AudioSystem Instance
    {
        get { return ((AudioSystem)_Instance); }
        set { _Instance = value; }
    }

    public void PlaySound(string resourceName)
    {
        if (!_source.isPlaying)
        {
            _loadedResource = Resources.Load(resourceName) as AudioClip;
            _source.PlayOneShot(_loadedResource);
        }
    }

    void Update()
    {
        if (!_source.isPlaying && _loadedResource != null)
        {
            Resources.UnloadAsset(_loadedResource);
            _loadedResource = null;
        }
    }
}
