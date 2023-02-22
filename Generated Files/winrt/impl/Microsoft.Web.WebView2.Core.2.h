// WARNING: Please don't edit this file. It was generated by C++/WinRT v2.0.220929.3

#pragma once
#ifndef WINRT_Microsoft_Web_WebView2_Core_2_H
#define WINRT_Microsoft_Web_WebView2_Core_2_H
#include "winrt/impl/Windows.Foundation.Collections.1.h"
#include "winrt/impl/Windows.UI.Core.1.h"
#include "winrt/impl/Microsoft.Web.WebView2.Core.1.h"
WINRT_EXPORT namespace winrt::Microsoft::Web::WebView2::Core
{
    struct CoreWebView2PhysicalKeyStatus
    {
        uint32_t RepeatCount;
        uint32_t ScanCode;
        int32_t IsExtendedKey;
        int32_t IsMenuKeyDown;
        int32_t WasKeyDown;
        int32_t IsKeyReleased;
    };
    inline bool operator==(CoreWebView2PhysicalKeyStatus const& left, CoreWebView2PhysicalKeyStatus const& right) noexcept
    {
        return left.RepeatCount == right.RepeatCount && left.ScanCode == right.ScanCode && left.IsExtendedKey == right.IsExtendedKey && left.IsMenuKeyDown == right.IsMenuKeyDown && left.WasKeyDown == right.WasKeyDown && left.IsKeyReleased == right.IsKeyReleased;
    }
    inline bool operator!=(CoreWebView2PhysicalKeyStatus const& left, CoreWebView2PhysicalKeyStatus const& right) noexcept
    {
        return !(left == right);
    }
    struct __declspec(empty_bases) CoreWebView2 : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2,
        impl::require<CoreWebView2, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2_10, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2_11, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2_12, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2_2, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2_3, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2_4, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2_5, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2_6, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2_7, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2_8, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2_9>
    {
        CoreWebView2(std::nullptr_t) noexcept {}
        CoreWebView2(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2AcceleratorKeyPressedEventArgs : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2AcceleratorKeyPressedEventArgs
    {
        CoreWebView2AcceleratorKeyPressedEventArgs(std::nullptr_t) noexcept {}
        CoreWebView2AcceleratorKeyPressedEventArgs(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2AcceleratorKeyPressedEventArgs(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2BasicAuthenticationRequestedEventArgs : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2BasicAuthenticationRequestedEventArgs
    {
        CoreWebView2BasicAuthenticationRequestedEventArgs(std::nullptr_t) noexcept {}
        CoreWebView2BasicAuthenticationRequestedEventArgs(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2BasicAuthenticationRequestedEventArgs(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2BasicAuthenticationResponse : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2BasicAuthenticationResponse
    {
        CoreWebView2BasicAuthenticationResponse(std::nullptr_t) noexcept {}
        CoreWebView2BasicAuthenticationResponse(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2BasicAuthenticationResponse(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2BrowserProcessExitedEventArgs : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2BrowserProcessExitedEventArgs
    {
        CoreWebView2BrowserProcessExitedEventArgs(std::nullptr_t) noexcept {}
        CoreWebView2BrowserProcessExitedEventArgs(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2BrowserProcessExitedEventArgs(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2ClientCertificate : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2ClientCertificate,
        impl::require<CoreWebView2ClientCertificate, winrt::Microsoft::Web::WebView2::Core::CoreWebView2ClientCertificate_Manual>
    {
        CoreWebView2ClientCertificate(std::nullptr_t) noexcept {}
        CoreWebView2ClientCertificate(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2ClientCertificate(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2ClientCertificateRequestedEventArgs : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2ClientCertificateRequestedEventArgs
    {
        CoreWebView2ClientCertificateRequestedEventArgs(std::nullptr_t) noexcept {}
        CoreWebView2ClientCertificateRequestedEventArgs(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2ClientCertificateRequestedEventArgs(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2CompositionController : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2CompositionController,
        impl::base<CoreWebView2CompositionController, winrt::Microsoft::Web::WebView2::Core::CoreWebView2Controller>,
        impl::require<CoreWebView2CompositionController, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2CompositionController2, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Controller2, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Controller3, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Controller4, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Controller>
    {
        CoreWebView2CompositionController(std::nullptr_t) noexcept {}
        CoreWebView2CompositionController(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2CompositionController(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2ContentLoadingEventArgs : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2ContentLoadingEventArgs
    {
        CoreWebView2ContentLoadingEventArgs(std::nullptr_t) noexcept {}
        CoreWebView2ContentLoadingEventArgs(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2ContentLoadingEventArgs(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2ContextMenuItem : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2ContextMenuItem
    {
        CoreWebView2ContextMenuItem(std::nullptr_t) noexcept {}
        CoreWebView2ContextMenuItem(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2ContextMenuItem(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2ContextMenuRequestedEventArgs : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2ContextMenuRequestedEventArgs
    {
        CoreWebView2ContextMenuRequestedEventArgs(std::nullptr_t) noexcept {}
        CoreWebView2ContextMenuRequestedEventArgs(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2ContextMenuRequestedEventArgs(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2ContextMenuTarget : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2ContextMenuTarget
    {
        CoreWebView2ContextMenuTarget(std::nullptr_t) noexcept {}
        CoreWebView2ContextMenuTarget(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2ContextMenuTarget(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2Controller : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Controller,
        impl::require<CoreWebView2Controller, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Controller2, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Controller3, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Controller4>
    {
        CoreWebView2Controller(std::nullptr_t) noexcept {}
        CoreWebView2Controller(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Controller(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2ControllerWindowReference : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2ControllerWindowReference
    {
        CoreWebView2ControllerWindowReference(std::nullptr_t) noexcept {}
        CoreWebView2ControllerWindowReference(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2ControllerWindowReference(ptr, take_ownership_from_abi) {}
        static auto CreateFromWindowHandle(uint64_t windowHandle);
        static auto CreateFromCoreWindow(winrt::Windows::UI::Core::CoreWindow const& coreWindow);
    };
    struct __declspec(empty_bases) CoreWebView2Cookie : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Cookie
    {
        CoreWebView2Cookie(std::nullptr_t) noexcept {}
        CoreWebView2Cookie(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Cookie(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2CookieManager : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2CookieManager,
        impl::require<CoreWebView2CookieManager, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2CookieManager_Manual>
    {
        CoreWebView2CookieManager(std::nullptr_t) noexcept {}
        CoreWebView2CookieManager(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2CookieManager(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2DOMContentLoadedEventArgs : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2DOMContentLoadedEventArgs
    {
        CoreWebView2DOMContentLoadedEventArgs(std::nullptr_t) noexcept {}
        CoreWebView2DOMContentLoadedEventArgs(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2DOMContentLoadedEventArgs(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2DevToolsProtocolEventReceivedEventArgs : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2DevToolsProtocolEventReceivedEventArgs,
        impl::require<CoreWebView2DevToolsProtocolEventReceivedEventArgs, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2DevToolsProtocolEventReceivedEventArgs2>
    {
        CoreWebView2DevToolsProtocolEventReceivedEventArgs(std::nullptr_t) noexcept {}
        CoreWebView2DevToolsProtocolEventReceivedEventArgs(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2DevToolsProtocolEventReceivedEventArgs(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2DevToolsProtocolEventReceiver : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2DevToolsProtocolEventReceiver
    {
        CoreWebView2DevToolsProtocolEventReceiver(std::nullptr_t) noexcept {}
        CoreWebView2DevToolsProtocolEventReceiver(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2DevToolsProtocolEventReceiver(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2DownloadOperation : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2DownloadOperation
    {
        CoreWebView2DownloadOperation(std::nullptr_t) noexcept {}
        CoreWebView2DownloadOperation(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2DownloadOperation(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2DownloadStartingEventArgs : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2DownloadStartingEventArgs
    {
        CoreWebView2DownloadStartingEventArgs(std::nullptr_t) noexcept {}
        CoreWebView2DownloadStartingEventArgs(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2DownloadStartingEventArgs(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2Environment : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Environment,
        impl::require<CoreWebView2Environment, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Environment2, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Environment3, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Environment4, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Environment5, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Environment6, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Environment7, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Environment8, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Environment9>
    {
        CoreWebView2Environment(std::nullptr_t) noexcept {}
        CoreWebView2Environment(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Environment(ptr, take_ownership_from_abi) {}
        static auto CreateAsync();
        static auto CreateWithOptionsAsync(param::hstring const& browserExecutableFolder, param::hstring const& userDataFolder, winrt::Microsoft::Web::WebView2::Core::CoreWebView2EnvironmentOptions const& options);
        static auto GetAvailableBrowserVersionString();
        static auto GetAvailableBrowserVersionString(param::hstring const& browserExecutableFolder);
        static auto CompareBrowserVersionString(param::hstring const& browserVersionString1, param::hstring const& browserVersionString2);
    };
    struct __declspec(empty_bases) CoreWebView2EnvironmentOptions : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2EnvironmentOptions,
        impl::require<CoreWebView2EnvironmentOptions, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2EnvironmentOptions2, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2EnvironmentOptions_Manual>
    {
        CoreWebView2EnvironmentOptions(std::nullptr_t) noexcept {}
        CoreWebView2EnvironmentOptions(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2EnvironmentOptions(ptr, take_ownership_from_abi) {}
        CoreWebView2EnvironmentOptions();
    };
    struct __declspec(empty_bases) CoreWebView2Frame : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Frame,
        impl::require<CoreWebView2Frame, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Frame2, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Frame3>
    {
        CoreWebView2Frame(std::nullptr_t) noexcept {}
        CoreWebView2Frame(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Frame(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2FrameCreatedEventArgs : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2FrameCreatedEventArgs
    {
        CoreWebView2FrameCreatedEventArgs(std::nullptr_t) noexcept {}
        CoreWebView2FrameCreatedEventArgs(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2FrameCreatedEventArgs(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2FrameInfo : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2FrameInfo
    {
        CoreWebView2FrameInfo(std::nullptr_t) noexcept {}
        CoreWebView2FrameInfo(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2FrameInfo(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2HttpHeadersCollectionIterator : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2HttpHeadersCollectionIterator,
        impl::require<CoreWebView2HttpHeadersCollectionIterator, winrt::Windows::Foundation::Collections::IIterator<winrt::Windows::Foundation::Collections::IKeyValuePair<hstring, hstring>>>
    {
        CoreWebView2HttpHeadersCollectionIterator(std::nullptr_t) noexcept {}
        CoreWebView2HttpHeadersCollectionIterator(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2HttpHeadersCollectionIterator(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2HttpRequestHeaders : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2HttpRequestHeaders,
        impl::require<CoreWebView2HttpRequestHeaders, winrt::Windows::Foundation::Collections::IIterable<winrt::Windows::Foundation::Collections::IKeyValuePair<hstring, hstring>>>
    {
        CoreWebView2HttpRequestHeaders(std::nullptr_t) noexcept {}
        CoreWebView2HttpRequestHeaders(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2HttpRequestHeaders(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2HttpResponseHeaders : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2HttpResponseHeaders,
        impl::require<CoreWebView2HttpResponseHeaders, winrt::Windows::Foundation::Collections::IIterable<winrt::Windows::Foundation::Collections::IKeyValuePair<hstring, hstring>>>
    {
        CoreWebView2HttpResponseHeaders(std::nullptr_t) noexcept {}
        CoreWebView2HttpResponseHeaders(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2HttpResponseHeaders(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2MoveFocusRequestedEventArgs : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2MoveFocusRequestedEventArgs
    {
        CoreWebView2MoveFocusRequestedEventArgs(std::nullptr_t) noexcept {}
        CoreWebView2MoveFocusRequestedEventArgs(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2MoveFocusRequestedEventArgs(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2NavigationCompletedEventArgs : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2NavigationCompletedEventArgs
    {
        CoreWebView2NavigationCompletedEventArgs(std::nullptr_t) noexcept {}
        CoreWebView2NavigationCompletedEventArgs(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2NavigationCompletedEventArgs(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2NavigationStartingEventArgs : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2NavigationStartingEventArgs,
        impl::require<CoreWebView2NavigationStartingEventArgs, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2NavigationStartingEventArgs2>
    {
        CoreWebView2NavigationStartingEventArgs(std::nullptr_t) noexcept {}
        CoreWebView2NavigationStartingEventArgs(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2NavigationStartingEventArgs(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2NewWindowRequestedEventArgs : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2NewWindowRequestedEventArgs,
        impl::require<CoreWebView2NewWindowRequestedEventArgs, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2NewWindowRequestedEventArgs2>
    {
        CoreWebView2NewWindowRequestedEventArgs(std::nullptr_t) noexcept {}
        CoreWebView2NewWindowRequestedEventArgs(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2NewWindowRequestedEventArgs(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2PermissionRequestedEventArgs : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2PermissionRequestedEventArgs,
        impl::require<CoreWebView2PermissionRequestedEventArgs, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2PermissionRequestedEventArgs2>
    {
        CoreWebView2PermissionRequestedEventArgs(std::nullptr_t) noexcept {}
        CoreWebView2PermissionRequestedEventArgs(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2PermissionRequestedEventArgs(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2PointerInfo : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2PointerInfo
    {
        CoreWebView2PointerInfo(std::nullptr_t) noexcept {}
        CoreWebView2PointerInfo(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2PointerInfo(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2PrintSettings : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2PrintSettings
    {
        CoreWebView2PrintSettings(std::nullptr_t) noexcept {}
        CoreWebView2PrintSettings(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2PrintSettings(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2ProcessFailedEventArgs : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2ProcessFailedEventArgs,
        impl::require<CoreWebView2ProcessFailedEventArgs, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2ProcessFailedEventArgs2>
    {
        CoreWebView2ProcessFailedEventArgs(std::nullptr_t) noexcept {}
        CoreWebView2ProcessFailedEventArgs(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2ProcessFailedEventArgs(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2ProcessInfo : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2ProcessInfo
    {
        CoreWebView2ProcessInfo(std::nullptr_t) noexcept {}
        CoreWebView2ProcessInfo(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2ProcessInfo(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2ScriptDialogOpeningEventArgs : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2ScriptDialogOpeningEventArgs
    {
        CoreWebView2ScriptDialogOpeningEventArgs(std::nullptr_t) noexcept {}
        CoreWebView2ScriptDialogOpeningEventArgs(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2ScriptDialogOpeningEventArgs(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2Settings : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Settings,
        impl::require<CoreWebView2Settings, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Settings2, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Settings3, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Settings4, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Settings5, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Settings6, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Settings7, winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Settings_Manual>
    {
        CoreWebView2Settings(std::nullptr_t) noexcept {}
        CoreWebView2Settings(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2Settings(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2SourceChangedEventArgs : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2SourceChangedEventArgs
    {
        CoreWebView2SourceChangedEventArgs(std::nullptr_t) noexcept {}
        CoreWebView2SourceChangedEventArgs(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2SourceChangedEventArgs(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2WebMessageReceivedEventArgs : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2WebMessageReceivedEventArgs
    {
        CoreWebView2WebMessageReceivedEventArgs(std::nullptr_t) noexcept {}
        CoreWebView2WebMessageReceivedEventArgs(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2WebMessageReceivedEventArgs(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2WebResourceRequest : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2WebResourceRequest
    {
        CoreWebView2WebResourceRequest(std::nullptr_t) noexcept {}
        CoreWebView2WebResourceRequest(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2WebResourceRequest(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2WebResourceRequestedEventArgs : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2WebResourceRequestedEventArgs
    {
        CoreWebView2WebResourceRequestedEventArgs(std::nullptr_t) noexcept {}
        CoreWebView2WebResourceRequestedEventArgs(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2WebResourceRequestedEventArgs(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2WebResourceResponse : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2WebResourceResponse
    {
        CoreWebView2WebResourceResponse(std::nullptr_t) noexcept {}
        CoreWebView2WebResourceResponse(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2WebResourceResponse(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2WebResourceResponseReceivedEventArgs : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2WebResourceResponseReceivedEventArgs
    {
        CoreWebView2WebResourceResponseReceivedEventArgs(std::nullptr_t) noexcept {}
        CoreWebView2WebResourceResponseReceivedEventArgs(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2WebResourceResponseReceivedEventArgs(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2WebResourceResponseView : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2WebResourceResponseView
    {
        CoreWebView2WebResourceResponseView(std::nullptr_t) noexcept {}
        CoreWebView2WebResourceResponseView(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2WebResourceResponseView(ptr, take_ownership_from_abi) {}
    };
    struct __declspec(empty_bases) CoreWebView2WindowFeatures : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2WindowFeatures
    {
        CoreWebView2WindowFeatures(std::nullptr_t) noexcept {}
        CoreWebView2WindowFeatures(void* ptr, take_ownership_from_abi_t) noexcept : winrt::Microsoft::Web::WebView2::Core::ICoreWebView2WindowFeatures(ptr, take_ownership_from_abi) {}
    };
}
#endif
