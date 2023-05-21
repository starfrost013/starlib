﻿using Starlib.Base;

namespace Starlib.Utilities
{
    /// <summary>
    /// NCMessageBoxPresets
    /// 
    /// Defines preset messageboxes for the NC Messagebox API. Public becasue it;s loaded using reflection if SDL2 is there
    /// </summary>
    public static class LightningMessageBoxPresets
    {
        /// <summary>
        /// Creates a generic message box with a single "OK" button.
        /// </summary>
        /// <param name="title">The title of the message box.</param>
        /// <param name="message">The content of the message box.</param>
        /// <param name="icon">The icon of the message box (optional) - see <see cref="SDL.SDL_MessageBoxFlags"></see></param>
        /// <returns>A <see cref="LightningMessageBoxButton"/> containing the selected button.</returns>
        public static LightningMessageBoxButton? MessageBoxOK(string title, string message, SDL.SDL_MessageBoxFlags icon = SDL.SDL_MessageBoxFlags.SDL_MESSAGEBOX_INFORMATION)
        {
            LightningMessageBox msgbox = CreateMessageBox(title, message, icon);
            msgbox.AddButton("OK", SDL.SDL_MessageBoxButtonFlags.SDL_MESSAGEBOX_BUTTON_RETURNKEY_DEFAULT);
            return msgbox.Show();
        }

        /// <summary>
        /// Creates a generic message box with "OK" and "Cancel" buttons.
        /// The OK button is the default used for the return key and the Cancel button the default for the escape key.
        /// </summary>
        /// <param name="title">The title of the message box.</param>
        /// <param name="message">The content of the message box.</param>
        /// <param name="icon">The icon of the message box (optional) - see <see cref="SDL.SDL_MessageBoxFlags"></see></param>
        /// <returns>A <see cref="LightningMessageBoxButton"/> containing the selected button.</returns>
        public static LightningMessageBoxButton? MessageBoxOKCancel(string title, string message, SDL.SDL_MessageBoxFlags icon = SDL.SDL_MessageBoxFlags.SDL_MESSAGEBOX_INFORMATION)
        {
            LightningMessageBox msgbox = CreateMessageBox(title, message, icon);
            msgbox.AddButton("OK", SDL.SDL_MessageBoxButtonFlags.SDL_MESSAGEBOX_BUTTON_RETURNKEY_DEFAULT);
            msgbox.AddButton("Cancel", SDL.SDL_MessageBoxButtonFlags.SDL_MESSAGEBOX_BUTTON_ESCAPEKEY_DEFAULT);
            return msgbox.Show();
        }

        /// <summary>
        /// Creates a generic message box with "Retry" and "Cancel" buttons.
        /// The Retry button is the default used for the return key and the Cancel button the default for the escape key.
        /// </summary>
        /// <param name="title">The title of the message box.</param>
        /// <param name="message">The content of the message box.</param>
        /// <param name="icon">The icon of the message box (optional) - see <see cref="SDL.SDL_MessageBoxFlags"></see></param>
        /// <returns>A <see cref="LightningMessageBoxButton"/> containing the selected button.</returns>
        public static LightningMessageBoxButton? MessageBoxRetryCancel(string title, string message, SDL.SDL_MessageBoxFlags icon = SDL.SDL_MessageBoxFlags.SDL_MESSAGEBOX_INFORMATION)
        {
            LightningMessageBox msgbox = CreateMessageBox(title, message, icon);
            msgbox.AddButton("Retry", SDL.SDL_MessageBoxButtonFlags.SDL_MESSAGEBOX_BUTTON_RETURNKEY_DEFAULT);
            msgbox.AddButton("Cancel", SDL.SDL_MessageBoxButtonFlags.SDL_MESSAGEBOX_BUTTON_ESCAPEKEY_DEFAULT);
            return msgbox.Show();
        }

        /// <summary>
        /// Creates a generic message box with "Yes" and "No" buttons.
        /// The Yes button is the default used for the return key and the No button the default for the escape key.
        /// </summary>
        /// <param name="title">The title of the message box.</param>
        /// <param name="message">The content of the message box.</param>
        /// <param name="icon">The icon of the message box (optional) - see <see cref="SDL.SDL_MessageBoxFlags"></see></param>
        /// <returns>A <see cref="LightningMessageBoxButton"/> containing the selected button.</returns>
        public static LightningMessageBoxButton? MessageBoxYesNo(string title, string message, SDL.SDL_MessageBoxFlags icon = SDL.SDL_MessageBoxFlags.SDL_MESSAGEBOX_INFORMATION)
        {
            LightningMessageBox msgbox = CreateMessageBox(title, message, icon);
            msgbox.AddButton("Yes", SDL.SDL_MessageBoxButtonFlags.SDL_MESSAGEBOX_BUTTON_RETURNKEY_DEFAULT);
            msgbox.AddButton("No", SDL.SDL_MessageBoxButtonFlags.SDL_MESSAGEBOX_BUTTON_ESCAPEKEY_DEFAULT);
            return msgbox.Show();
        }

        /// <summary>
        /// Creates a generic message box with "Yes", "No", and "Cancel" buttons.
        /// The Yes button is the default used for the return key and the Cancel button the default for the escape key.
        /// </summary>
        /// <param name="title">The title of the message box.</param>
        /// <param name="message">The content of the message box.</param>
        /// <param name="icon">The icon of the message box (optional) - see <see cref="SDL.SDL_MessageBoxFlags"></see></param>
        /// <returns>A <see cref="LightningMessageBoxButton"/> containing the selected button.</returns>
        public static LightningMessageBoxButton? MessageBoxYesNoCancel(string title, string message, SDL.SDL_MessageBoxFlags icon = SDL.SDL_MessageBoxFlags.SDL_MESSAGEBOX_INFORMATION)
        {
            LightningMessageBox msgbox = CreateMessageBox(title, message, icon);
            msgbox.AddButton("Yes", SDL.SDL_MessageBoxButtonFlags.SDL_MESSAGEBOX_BUTTON_RETURNKEY_DEFAULT);
            msgbox.AddButton("No");
            msgbox.AddButton("Cancel", SDL.SDL_MessageBoxButtonFlags.SDL_MESSAGEBOX_BUTTON_ESCAPEKEY_DEFAULT);
            return msgbox.Show();

        }

        /// <summary>
        /// Creates a generic message box with "Abort", "Retry", and "Ignore" buttons.
        /// The Retry button is the default used for the return key and the Abort button the default for the escape key.
        /// </summary>
        /// <param name="title">The title of the message box.</param>
        /// <param name="message">The content of the message box.</param>
        /// <param name="icon">The icon of the message box (optional) - see <see cref="SDL.SDL_MessageBoxFlags"></see></param>
        /// <returns>A <see cref="LightningMessageBoxButton"/> containing the selected button.</returns>
        public static LightningMessageBoxButton? MessageBoxAbortRetryIgnore(string title, string message, SDL.SDL_MessageBoxFlags icon = SDL.SDL_MessageBoxFlags.SDL_MESSAGEBOX_INFORMATION)
        {
            LightningMessageBox msgbox = CreateMessageBox(title, message, icon);
            msgbox.AddButton("Abort", SDL.SDL_MessageBoxButtonFlags.SDL_MESSAGEBOX_BUTTON_ESCAPEKEY_DEFAULT);
            msgbox.AddButton("Retry", SDL.SDL_MessageBoxButtonFlags.SDL_MESSAGEBOX_BUTTON_RETURNKEY_DEFAULT);
            msgbox.AddButton("Ignore");
            return msgbox.Show();
        }

        /// <summary>
        /// Creates a generic message box with "Cancel", "Try", and "Continue" buttons.
        /// The Continue button is the default used for the return key and the Cancel button the default for the escape key.
        /// </summary>
        /// <param name="title">The title of the message box.</param>
        /// <param name="message">The content of the message box.</param>
        /// <param name="icon">The icon of the message box (optional) - see <see cref="SDL.SDL_MessageBoxFlags"></see></param>
        /// <returns>A <see cref="LightningMessageBoxButton"/> containing the selected button.</returns>
        public static LightningMessageBoxButton? MessageBoxCancelTryContinue(string title, string message, SDL.SDL_MessageBoxFlags icon = SDL.SDL_MessageBoxFlags.SDL_MESSAGEBOX_INFORMATION)
        {
            LightningMessageBox msgbox = CreateMessageBox(title, message, icon);
            msgbox.AddButton("Cancel");
            msgbox.AddButton("Try", SDL.SDL_MessageBoxButtonFlags.SDL_MESSAGEBOX_BUTTON_RETURNKEY_DEFAULT);
            msgbox.AddButton("Continue", SDL.SDL_MessageBoxButtonFlags.SDL_MESSAGEBOX_BUTTON_ESCAPEKEY_DEFAULT);
            return msgbox.Show();
        }

        /// <summary>
        /// Internal method for creating preset messageboxes.
        /// </summary>
        /// <param name="title">The title of the message box.</param>
        /// <param name="message">The content of the message box.</param>
        /// <param name="icon">The icon of the message box (optional) - see <see cref="SDL.SDL_MessageBoxFlags"></see></param>
        /// <returns></returns>
        private static LightningMessageBox CreateMessageBox(string title, string message, SDL.SDL_MessageBoxFlags icon = SDL.SDL_MessageBoxFlags.SDL_MESSAGEBOX_INFORMATION)
        {
            return new LightningMessageBox
            {
                Title = title,
                Text = message,
                Icon = icon,
            };
        }
    }
}
