#region License
/* Lightning SDL2_mixer Wrapper
 * 
 * Version 3.1.0
 * Copyright � 2022 starfrost
 * August 31, 2022
 * 
 * This software is based on the open-source SDL2# - C# Wrapper for SDL2 library.
 *
 * Copyright � 2013-2021 Ethan Lee.
 * Copyright � 2022 starfrost
 * 
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from
 * the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 * claim that you wrote the original software. If you use this software in a
 * product, an acknowledgment in the product documentation would be
 * appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not be
 * misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source distribution.
 *
 * Ethan "flibitijibibo" Lee <flibitijibibo@flibitijibibo.com>
 *
 */
#endregion

#region Using Statements
using static Starlib.Base.SdlMarshaling;
using static Starlib.Base.Utf8Marshaling;
#endregion

namespace Starlib.Base
{
    public static class SDL_mixer
    {
        #region SDL2# Variables

        /* Used by DllImport to load the native library. */
        private const string nativeLibName = @"SDL2_mixer";

        #endregion

        /* Similar to the headers, this is the version we're expecting to be
		 * running with. You will likely want to check this somewhere in your
		 * program!
		 */
        public const int SDL_MIXER_EXPECTED_MAJOR_VERSION = 2;
        public const int SDL_MIXER_EXPECTED_MINOR_VERSION = 6;
        public const int SDL_MIXER_EXPECTED_PATCHLEVEL = 3;

        /* In C, you can redefine this value before including SDL_mixer.h.
		 * We're not going to allow this in SDL2#, since the value of this
		 * variable is persistent and not dependent on preprocessor ordering.
		 */
        public static int MIX_CHANNELS { get; private set; }

        public static readonly int MIX_DEFAULT_FREQUENCY = 44100;
        public static readonly ushort MIX_DEFAULT_FORMAT =
            (ushort)(BitConverter.IsLittleEndian ? Mix_AudioFormat.AUDIO_S16LSB : Mix_AudioFormat.AUDIO_S16MSB); // why is there a cast here? it inherits from ushort...
        public static readonly int MIX_DEFAULT_CHANNELS = 2;
        public static readonly byte MIX_MAX_VOLUME = 128;

        #region Enums and structs
        [Flags]
        public enum MIX_InitFlags
        {
            MIX_INIT_FLAC = 0x00000001,
            MIX_INIT_MOD = 0x00000002,
            MIX_INIT_MP3 = 0x00000008,
            MIX_INIT_OGG = 0x00000010,
            MIX_INIT_MID = 0x00000020,
            MIX_INIT_OPUS = 0x00000040,
            MIX_INIT_EVERYTHING = (MIX_INIT_FLAC | MIX_INIT_MOD | MIX_INIT_MP3 | MIX_INIT_OGG | MIX_INIT_MID | MIX_INIT_OPUS)
        }

        public struct MIX_Chunk
        {
            public int allocated;
            public nint abuf; /* Uint8* */
            public uint alen;
            public byte volume;
        }

        public enum Mix_Fading
        {
            MIX_NO_FADING,
            MIX_FADING_OUT,
            MIX_FADING_IN
        }

        public enum Mix_MusicType
        {
            MUS_NONE,
            MUS_CMD,
            MUS_WAV,
            MUS_MOD,
            MUS_MID,
            MUS_OGG,
            MUS_MP3,
            MUS_MP3_MAD_UNUSED,
            MUS_FLAC,
            MUS_MODPLUG_UNUSED,
            MUS_OPUS
        }

        #endregion

        #region Delegates
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void MixFuncDelegate(
            nint udata, // void*
            nint stream, // Uint8*
            int len
        );

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void Mix_EffectFunc_t(
            int chan,
            nint stream, // void*
            int len,
            nint udata // void*
        );

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void Mix_EffectDone_t(
            int chan,
            nint udata // void*
        );

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void MusicFinishedDelegate();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ChannelFinishedDelegate(int channel);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int SoundFontDelegate(
            nint a, // const char*
            nint b // void*
        );
        #endregion

        #region Versioning
        public static void Mix_Version(out SDL_version x)
        {
            x.major = SDL_MIXER_EXPECTED_MAJOR_VERSION;
            x.minor = SDL_MIXER_EXPECTED_MINOR_VERSION;
            x.patch = SDL_MIXER_EXPECTED_PATCHLEVEL;
        }

        public static readonly int SDL_MIXER_EXPECTED_COMPILEDVERSION = SDL_VERSIONNUM
        (
            SDL_MIXER_EXPECTED_MAJOR_VERSION,
            SDL_MIXER_EXPECTED_MINOR_VERSION,
            SDL_MIXER_EXPECTED_PATCHLEVEL
        );

        [DllImport(nativeLibName, EntryPoint = "Mix_Linked_Version", CallingConvention = CallingConvention.Cdecl)]
        private static extern nint INTERNAL_Mix_Linked_Version();

        public static bool Mix_VERSION_ATLEAST(int X, int Y, int Z) => SDL_MIXER_EXPECTED_COMPILEDVERSION >= SDL_VERSIONNUM(X, Y, Z);
        public static SDL_version Mix_Linked_Version()
        {
            SDL_version result;
            nint result_ptr = INTERNAL_Mix_Linked_Version();
            result = PtrToStructure<SDL.SDL_version>(
                    result_ptr
                );
            return result;
        }

        #endregion

        #region Functions
        [DllImport(nativeLibName, EntryPoint = "Mix_Init", CallingConvention = CallingConvention.Cdecl)]
        public static extern int INTERNAL_Mix_Init(MIX_InitFlags FLAGS);

        public static int Mix_Init(MIX_InitFlags flags)
        {
            // check for version information
            // verify a sufficient SDL version (as we dynamically link) - get the real version of SDL2.dll to do this
            SDL_version realVersion = Mix_Linked_Version();

            bool versionIsCompatible = Mix_VERSION_ATLEAST(SDL_MIXER_EXPECTED_MAJOR_VERSION, SDL_MIXER_EXPECTED_MINOR_VERSION, SDL_MIXER_EXPECTED_PATCHLEVEL);

            // if SDL is too load
            if (!versionIsCompatible)
            {
                Mix_SetError($"Incorrect SDL_mixer version. Version {SDL_MIXER_EXPECTED_MAJOR_VERSION}.{SDL_MIXER_EXPECTED_MINOR_VERSION}.{SDL_MIXER_EXPECTED_PATCHLEVEL} is required," +
                    $" got {realVersion.major}.{realVersion.minor}.{realVersion.patch}!");
                return -94003; // NEGATIVE is an error code
            }

            return INTERNAL_Mix_Init(flags);
        }

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_Quit();

        [DllImport(nativeLibName, EntryPoint = "Mix_OpenAudio", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_Mix_OpenAudio(
            int frequency,
            ushort format,
            int channels,
            int chunksize
        );

        public static int Mix_OpenAudio(int frequency, Mix_AudioFormat format, int channels, int chunksize) => INTERNAL_Mix_OpenAudio(frequency, (ushort)format, channels, chunksize);

        [DllImport(nativeLibName, EntryPoint = "Mix_AllocateChannels", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_Mix_AllocateChannels(int numchans);

        public static int Mix_AllocateChannels(int numchans)
        {
            MIX_CHANNELS = INTERNAL_Mix_AllocateChannels((ushort)numchans);
            return MIX_CHANNELS;
        }

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_QuerySpec(
            out int frequency,
            out ushort format,
            out int channels
        );

        /* src refers to an SDL_RWops*, nint to a Mix_Chunk* */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nint Mix_LoadWAV_RW(
            nint src,
            int freesrc
        );

        /* nint refers to a Mix_Chunk* */
        /* This is an RWops macro in the C header. */
        public static nint Mix_LoadWAV(string file)
        {
            nint rwops = SDL_RWFromFile(file, "rb");
            return Mix_LoadWAV_RW(rwops, 1);
        }

        /* nint refers to a Mix_Music* */
        [DllImport(nativeLibName, EntryPoint = "Mix_LoadMUS", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe nint INTERNAL_Mix_LoadMUS(
            byte* file
        );
        public static unsafe nint Mix_LoadMUS(string file)
        {
            byte* utf8File = Utf8EncodeHeap(file);
            nint handle = INTERNAL_Mix_LoadMUS(
                utf8File
            );
            Marshal.FreeHGlobal((nint)utf8File);
            return handle;
        }

        /* nint refers to a Mix_Chunk* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nint Mix_QuickLoad_WAV(
            [In()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1)]
                byte[] mem
        );

        /* nint refers to a Mix_Chunk* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nint Mix_QuickLoad_RAW(
            [In()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)]
                byte[] mem,
            uint len
        );

        /* chunk refers to a Mix_Chunk* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_FreeChunk(nint chunk);

        /* music refers to a Mix_Music* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_FreeMusic(nint music);


        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GetNumChunkDecoders();

        [DllImport(nativeLibName, EntryPoint = "Mix_GetChunkDecoder", CallingConvention = CallingConvention.Cdecl)]
        private static extern nint INTERNAL_Mix_GetChunkDecoder(int index);
        public static string Mix_GetChunkDecoder(int index)
        {
            return UTF8_ToManaged(
                INTERNAL_Mix_GetChunkDecoder(index)
            );
        }

        [DllImport(nativeLibName, EntryPoint = "Mix_HasMusicDecoder", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe SDL_bool INTERNAL_Mix_HasMusicDecoder(byte* name);
        public static unsafe SDL_bool Mix_HasMusicDecoder(string name)
        {
            int utf8Size = Utf8Size(name);
            byte* buffer = stackalloc byte[utf8Size];
            return INTERNAL_Mix_HasMusicDecoder(Utf8Encode(name, buffer, utf8Size));
        }

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GetNumMusicDecoders();

        [DllImport(nativeLibName, EntryPoint = "Mix_GetMusicDecoder", CallingConvention = CallingConvention.Cdecl)]
        private static extern nint INTERNAL_Mix_GetMusicDecoder(int index);
        public static string Mix_GetMusicDecoder(int index)
        {
            return UTF8_ToManaged(
                INTERNAL_Mix_GetMusicDecoder(index)
            );
        }

        /* music refers to a Mix_Music* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mix_MusicType Mix_GetMusicType(nint music);

        /* music refers to a Mix_Music*
		 * Only available in 2.0.5 or higher.
		 */
        [DllImport(nativeLibName, EntryPoint = "Mix_GetMusicTitle", CallingConvention = CallingConvention.Cdecl)]
        public static extern nint INTERNAL_Mix_GetMusicTitle(nint music);
        public static string Mix_GetMusicTitle(nint music)
        {
            return UTF8_ToManaged(
                INTERNAL_Mix_GetMusicTitle(music)
            );
        }

        /* music refers to a Mix_Music*
		 * Only available in 2.6.0 or higher.
		 */
        [DllImport(nativeLibName, EntryPoint = "Mix_GetMusicTitleTag", CallingConvention = CallingConvention.Cdecl)]
        public static extern nint INTERNAL_Mix_GetMusicTitleTag(nint music);
        public static string Mix_GetMusicTitleTag(nint music)
        {
            return UTF8_ToManaged(
                INTERNAL_Mix_GetMusicTitleTag(music)
            );
        }

        /* music refers to a Mix_Music*
		 * Only available in 2.6.0 or higher.
		 */
        [DllImport(nativeLibName, EntryPoint = "Mix_GetMusicArtistTag", CallingConvention = CallingConvention.Cdecl)]
        public static extern nint INTERNAL_Mix_GetMusicArtistTag(nint music);
        public static string Mix_GetMusicArtistTag(nint music)
        {
            return UTF8_ToManaged(
                INTERNAL_Mix_GetMusicArtistTag(music)
            );
        }

        /// <summary>
        /// Audio formats
        /// 
        /// May 4, 2021 for Lightning
        /// August 25, 2022: Make inherit from ushort
        /// TODO: Move all existing code to use this?
        /// </summary>
        public enum Mix_AudioFormat : ushort
        {
            UDIO_U8 = 0x0008,
            AUDIO_S8 = 0x8008,
            AUDIO_U16LSB = 0x0010,
            AUDIO_S16LSB = 0x8010,
            AUDIO_U16MSB = 0x1010,
            AUDIO_S16MSB = 0x9010,
            AUDIO_U16 = AUDIO_U16LSB,
            AUDIO_S16 = AUDIO_S16LSB,
            AUDIO_S32LSB = 0x8020,
            AUDIO_S32MSB = 0x9020,
            AUDIO_S32 = AUDIO_S32LSB,
            AUDIO_F32LSB = 0x8120,
            AUDIO_F32MSB = 0x9120,
            AUDIO_F32 = AUDIO_F32LSB,

            AUDIO_U16SYS = AUDIO_U16LSB,
            AUDIO_S16SYS = AUDIO_S16LSB,
            AUDIO_S32SYS = AUDIO_S16LSB,
            AUDIO_F32SYS = AUDIO_F32LSB,

            MIX_DEFAULT_FORMAT = AUDIO_S16SYS
        }

        /* music refers to a Mix_Music*
		 * Only available in 2.6.0 or higher.
		 */
        [DllImport(nativeLibName, EntryPoint = "Mix_GetMusicAlbumTag", CallingConvention = CallingConvention.Cdecl)]
        public static extern nint INTERNAL_Mix_GetMusicAlbumTag(nint music);
        public static string Mix_GetMusicAlbumTag(nint music)
        {
            return UTF8_ToManaged(
                INTERNAL_Mix_GetMusicAlbumTag(music)
            );
        }

        /* music refers to a Mix_Music*
		 * Only available in 2.6.0 or higher.
		 */
        [DllImport(nativeLibName, EntryPoint = "Mix_GetMusicCopyrightTag", CallingConvention = CallingConvention.Cdecl)]
        public static extern nint INTERNAL_Mix_GetMusicCopyrightTag(nint music);
        public static string Mix_GetMusicCopyrightTag(nint music)
        {
            return UTF8_ToManaged(
                INTERNAL_Mix_GetMusicCopyrightTag(music)
            );
        }

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_SetPostMix(
            MixFuncDelegate mix_func,
            nint arg // void*
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_HookMusic(
            MixFuncDelegate mix_func,
            nint arg // void*
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_HookMusicFinished(
            MusicFinishedDelegate music_finished
        );

        /* nint refers to a void* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nint Mix_GetMusicHookData();

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_ChannelFinished(
            ChannelFinishedDelegate channel_finished
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_RegisterEffect(
            int chan,
            Mix_EffectFunc_t f,
            Mix_EffectDone_t d,
            nint arg // void*
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_UnregisterEffect(
            int channel,
            Mix_EffectFunc_t f
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_UnregisterAllEffects(int channel);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_SetPanning(
            int channel,
            byte left,
            byte right
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_SetPosition(
            int channel,
            short angle,
            byte distance
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_SetDistance(int channel, byte distance);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_SetReverseStereo(int channel, int flip);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_ReserveChannels(int num);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GroupChannel(int which, int tag);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GroupChannels(int from, int to, int tag);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GroupAvailable(int tag);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GroupCount(int tag);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GroupOldest(int tag);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GroupNewer(int tag);

        /* chunk refers to a Mix_Chunk* */
        public static int Mix_PlayChannel(
            int channel,
            nint chunk,
            int loops
        )
        {
            return Mix_PlayChannelTimed(channel, chunk, loops, -1);
        }

        /* chunk refers to a Mix_Chunk* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_PlayChannelTimed(
            int channel,
            nint chunk,
            int loops,
            int ticks
        );

        /* music refers to a Mix_Music* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_PlayMusic(nint music, int loops);

        /* music refers to a Mix_Music* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_FadeInMusic(
            nint music,
            int loops,
            int ms
        );

        /* music refers to a Mix_Music* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_FadeInMusicPos(
            nint music,
            int loops,
            int ms,
            double position
        );

        /* chunk refers to a Mix_Chunk* */
        public static int Mix_FadeInChannel(
            int channel,
            nint chunk,
            int loops,
            int ms
        )
        {
            return Mix_FadeInChannelTimed(channel, chunk, loops, ms, -1);
        }

        /* chunk refers to a Mix_Chunk* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_FadeInChannelTimed(
            int channel,
            nint chunk,
            int loops,
            int ms,
            int ticks
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_Volume(int channel, int volume);

        /* -1 to query 
         * Only available in 2.6.0 or later */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_MasterVolume(int volume);

        /* chunk refers to a Mix_Chunk* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_VolumeChunk(
            nint chunk,
            int volume
        );

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_VolumeMusic(int volume);

        /* music refers to a Mix_Music*
		 * Only available in 2.0.5 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GetVolumeMusicStream(nint music);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_HaltChannel(int channel);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_HaltGroup(int tag);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_HaltMusic();

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_ExpireChannel(int channel, int ticks);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_FadeOutChannel(int which, int ms);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_FadeOutGroup(int tag, int ms);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_FadeOutMusic(int ms);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mix_Fading Mix_FadingMusic();

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Mix_Fading Mix_FadingChannel(int which);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_Pause(int channel);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_Resume(int channel);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_Paused(int channel);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_PauseMusic();

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_ResumeMusic();

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_RewindMusic();

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_PausedMusic();

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_SetMusicPosition(double position);

        /* music refers to a Mix_Music*
		 * Only available in 2.6.0 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double Mix_GetMusicPosition(nint music);

        /* music refers to a Mix_Music*
		 * Only available in 2.6.0 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double Mix_MusicDuration(nint music);

        /* music refers to a Mix_Music*
		 * Only available in 2.6.0 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double Mix_GetMusicLoopStartTime(nint music);

        /* music refers to a Mix_Music*
		 * Only available in 2.6.0 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double Mix_GetMusicLoopEndTime(nint music);

        /* music refers to a Mix_Music*
		 * Only available in 2.6.0 or higher.
		 */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double Mix_GetMusicLoopLengthTime(nint music);

        /* music refers to a Mix_Music*
        * Only available in 2.6.0 or higher.
        */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GetMusicVolume(nint music);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_Playing(int channel);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_PlayingMusic();

        [DllImport(nativeLibName, EntryPoint = "Mix_SetMusicCMD", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int INTERNAL_Mix_SetMusicCMD(
            byte* command
        );
        public static unsafe int Mix_SetMusicCMD(string command)
        {
            byte* utf8Cmd = Utf8EncodeHeap(command);
            int result = INTERNAL_Mix_SetMusicCMD(
                utf8Cmd
            );
            Marshal.FreeHGlobal((nint)utf8Cmd);
            return result;
        }

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_SetSynchroValue(int value);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_GetSynchroValue();

        [DllImport(nativeLibName, EntryPoint = "Mix_SetSoundFonts", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int INTERNAL_Mix_SetSoundFonts(
            byte* paths
        );
        public static unsafe int Mix_SetSoundFonts(string paths)
        {
            byte* utf8Paths = Utf8EncodeHeap(paths);
            int result = INTERNAL_Mix_SetSoundFonts(
                utf8Paths
            );
            Marshal.FreeHGlobal((nint)utf8Paths);
            return result;
        }

        [DllImport(nativeLibName, EntryPoint = "Mix_GetSoundFonts", CallingConvention = CallingConvention.Cdecl)]
        private static extern nint INTERNAL_Mix_GetSoundFonts();
        public static string Mix_GetSoundFonts()
        {
            return UTF8_ToManaged(
                INTERNAL_Mix_GetSoundFonts()
            );
        }

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_EachSoundFont(
            SoundFontDelegate function,
            nint data // void*
        );

        /* Only available in 2.6.0 or later. */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mix_SetTimidityCfg(
            [In()] [MarshalAs(UnmanagedType.LPStr)]
                string path
        );

        /* Only available in 2.0.5 or later. */
        [DllImport(nativeLibName, EntryPoint = "Mix_GetTimidityCfg", CallingConvention = CallingConvention.Cdecl)]
        public static extern nint INTERNAL_Mix_GetTimidityCfg();
        public static string Mix_GetTimidityCfg()
        {
            return UTF8_ToManaged(
                INTERNAL_Mix_GetTimidityCfg()
            );
        }

        /* nint refers to a Mix_Chunk* */
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nint Mix_GetChunk(int channel);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Mix_CloseAudio();

        // New from upstream - March 5, 2022

        public static string Mix_GetError() => SDL_GetError();

        public static void Mix_SetError(string fmtAndArglist) => SDL_SetError(fmtAndArglist);

        public static void Mix_ClearError() => SDL_ClearError();


        #endregion
    }
}
