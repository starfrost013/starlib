﻿using static Starlib.Bindings.SDL;

namespace Starlib.Utilities
{
    /// <summary>
    /// NCMessageBox
    /// 
    /// February 26, 2022 (updated August 10, 2022) 
    /// 
    /// Platform-independent API for message boxes
    /// </summary>
    public class LightningMessageBox
    {
        /// <summary>
        /// Icon of the message box.
        /// </summary>
        public SDL_MessageBoxFlags Icon { get; set; }

        /// <summary>
        /// The title to use for the message box window.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// The text to use in the message box wiodow,
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// The buttons that are to be used in this message box.
        /// </summary>
        private List<LightningMessageBoxButton> Buttons { get; set; }

        /// <summary>
        /// Constructor for <see cref="LightningMessageBox"/>
        /// </summary>
        public LightningMessageBox()
        {
            Buttons = new List<LightningMessageBoxButton>();
        }

        /// <summary>
        /// Adds a button to this NCMessageBox.
        /// </summary>
        /// <param name="text">The text of this message box button.</param>
        /// <param name="flags">The flags - see <see cref="SDL.SDL_MessageBoxButtonFlags"/>.</param>
        public void AddButton(string text, SDL_MessageBoxButtonFlags flags = 0)
        {
            Buttons.Add(new LightningMessageBoxButton
            {
                Flags = flags,
                ID = Buttons.Count,
                Text = text,
            });
        }

        /// <summary>
        /// Shows this message box.
        /// </summary>
        /// <returns>A value indicating if this message box was returned or not.</returns>
        public LightningMessageBoxButton? Show()
        {
            // Create a new list of button data.
            List<SDL_MessageBoxButtonData> buttonData = new();

            foreach (LightningMessageBoxButton button in Buttons)
            {
                // use the explicit operator to convert
                buttonData.Add((SDL_MessageBoxButtonData)button);
            }

            // build the message box data
            SDL_MessageBoxButtonData[] buttonArray = buttonData.ToArray();

            SDL_MessageBoxData mbData = new()
            {
                // parent window currently not supported
                buttons = buttonArray,
                numbuttons = buttonArray.Length,
                title = Title,
                message = Text,
                flags = Icon
            };

            // Show the message box
            if (SDL_ShowMessageBox(ref mbData, out var buttonId) < 0)
            {
                Logger.LogError($"Error creating SDL message box - {SDL_GetError()}", 19, LoggerSeverity.Error);
                return null;
            }

            Debug.Assert(buttonId < buttonArray.Length);

            if (buttonId == -1) // No button selected
            {
                return null;
            }
            else
            {
                return Buttons[buttonId];
            }

        }
    }
}
