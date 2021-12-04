using System.Collections.Generic;

namespace VRCLinuxAssistant.Classes
{
    public class HardcodedCategories
    {
        private static readonly Dictionary<string, List<string>> CategoryContents = new()
        {
            {"Safety & Security", new() {"Advanced Safety", "Finitizer", "True Shader Anticrash", "Safety-Presets", "Final IK Sanity"}},
            {"Core mods and libraries", new() {"UI Expansion Kit", "ActionMenuApi", "VRCModUpdater.Loader", "VRChatUtilityKit"}},
            {"All-in-one mods", new() {"emmVRCLoader"}},
            {"Camera mods", new() {
                "CameraMinus", "DesktopCamera", "BetterSteadycam", "ITR's Melon Cameras", "CameraResChanger",
                "LocalCameraMod", "Lag Free Screenshots"
            }},
            {"Performance & Fidelity", new() {
                "Core Limiter", "MirrorResolutionUnlimiter", "AvatarHider", "Runtime Graphics Settings",
                "GamePriority", "FrameFocus", "ClearVRAM", "NoPerformanceStats", "Turbones"
            }},
            {"Utilities & Tweaks", new() {
                "ReloadAvatars", "KeyboardPaste", "No Outlines", "UnmuteSound", "SparkleBeGone",
                "BTKSAImmersiveHud", "OGTrustRanks", "ToggleMicIcon", "Friends+ home",
                "MicSensitivity", "CloningBeGone", "ToggleFullScreen", "View Point Tweaker",
                "SettingsRestart", "SmallUserVolume", "TeleportCameraToYou",
                "BetterPortalPlacement", "BetterDirections", "ChairExitController",
                "Panic Button Rework", "SelectYourself", "Trust Color Changer", "Voice Falloff Override"
            }},
            {"Hardware support", new() {"LeapMotionExtension", "ThumbParams", "VRCFaceTracking", "VRCPimaxEyeTracker", "VRCBhapticsIntegration"}},
            {"Dynamic bones", new() {
                "ImmersiveTouch", "Dynamic Bones Safety", "MultiplayerDynamicBonesMod", "Multiplayer Dynamic Bones",
            }},
            {"World tweaks", new() {
                "PostProcessing", "NearClipPlaneAdj", "RemoveChairs", "ComponentToggle", "No Grabby Hands", "AOOverride"
            }},
            {"Fixes", new() {"Invite+ fix", "CursorLockFix", "DownloadFix", "ProneUiFix"}},
            {"New features & Overhauls", new() {
                "IKTweaks", "JoinNotifier", "FBT Saver", "BTKSANameplateMod", "AdvancedInvites", "VRCVideoLibrary",
                "BTKSASelfPortrait", "OldMate", "BetterLoadingScreen", "Loading Screen Pictures", "FavCat",
                "ActionMenuUtils", "WorldPredownload", "AskToPortal", "Headlight", "ITR's Player Tracer",
                "InstanceHistory", "PortableMirrorMod", "VRCBonesController", "CalibrationLinesVisualizer",
                "ITR's Collider Mod", "RememberMe", "TriggerESP"
            }},
            {"UI mods", new() {
                "Particle and DynBone limiter settings UI", "CalibrateConfirm", "Emoji Page Buttons",
                "UserInfoExtensions", "MLConsoleViewer", "OwO Mod", "ActiveBackground", "PlayerList", "ComfyVRMenu",
                "DiscordMute", "MicToggle", "VRCPlusPet", "AMMusic", "Friend Notes", "GestureIndicator",
                "NameplateStats", "PreviewScroller", "ProPlates", "QuickMenuVolume", "ToggleUIStickers"
            }},
            {"Movement", new() {
                "TeleporterVR", "ImmobilizePlayerMod", "TrackingRotator", "OculusPlayspaceMover",
                "ITR's Gravity Controller", "QMFreeze", "Double-Tap Runner", "Player Rotater",
                "HeadTurn"
            }},
            {"Very Niche Mods", new() {"HWIDPatch", "No Steam. At all.", "Vertex Animation Remover", "LocalPlayerPrefs", "BTKSAGestureMod",}}
        };

        private static readonly Dictionary<string, string> CategoryDescriptions = new()
        {
            {"Safety & Security", "Crash less, block annoyances"},
            {"Core mods and libraries", "Other mods might require these"},
            {"All-in-one mods", "It does a lot of stuff"},
            {"Camera mods", "For all your screenshot or streaming needs"},
            {"Performance & Fidelity", "Improve performance or make the game look better"},
            {"Utilities & Tweaks", "Small mods that address specific issues"},
            {"Hardware support", "For all exotic hardware out there"},
            {"Dynamic bones", "Mods that affect jiggly bits"},
            {"World tweaks", "Change aspects of the world you're in"},
            {"Fixes", "It's not a bug, it's a feature"},
            {"New features & Overhauls", "Mods that introduce new features or significantly change existing ones"},
            {"UI mods", "Modify the user interface or introduce new functionality to it"},
            {"Movement", "Move in new exciting ways"},
            {"Very Niche Mods", "Only use these if you're really sure you need them"}
        };

        private static readonly Dictionary<string, string> ModNameToCategory = new();

        static HardcodedCategories()
        {
            foreach (var keyValuePair in CategoryContents)
            foreach (var s in keyValuePair.Value)
                ModNameToCategory.Add(s.ToLowerInvariant(), keyValuePair.Key);
        }

        public static string GetCategoryFor(Mod mod)
        {
            foreach (var alias in mod.aliases)
            {
                if (ModNameToCategory.TryGetValue(alias.ToLowerInvariant(), out var result)) return result;
            }

            foreach (var version in mod.versions)
            {
                if (ModNameToCategory.TryGetValue(version.name.ToLowerInvariant(), out var result)) return result;
            }

            return null;
        }

        public static string GetCategoryDescription(string category)
        {
            return CategoryDescriptions.TryGetValue(category, out var result) ? result : "";
        }

        private static List<(string Original, string Replace)> ourAuthorReplaces =
            new()
            {
                ("<@!170953680718266369>", "ImTiara"),
                ("<@!286669951987613706>", "Rafa"),
                ("<@!168795588366696450>", "Grummus"),
                ("<@!167335587488071682>", "KortyBoi/Lily"),
                ("<@!127978642981650432>", "tetra"),
                ("<@!155396491853168640>", "Dawn/arion")
            };

        public static string FixupAuthor(string authorName)
        {
            if (string.IsNullOrEmpty(authorName) || !authorName.Contains("@")) return authorName;

            foreach (var authorReplace in ourAuthorReplaces)
                authorName = authorName.Replace(authorReplace.Original, authorReplace.Replace);

            return authorName;
        }
    }
}