// Copyright 2026 DeepL SE (https://www.deepl.com)
// Use of this source code is governed by an MIT
// license that can be found in the LICENSE file.

using System.Collections.Generic;

namespace DeepL.Model {
  /// <summary>
  ///   A DeepL API resource and the features it supports, as returned by
  ///   <see cref="DeepLClient.GetLanguageResourcesAsync" />.
  /// </summary>
  public sealed class LanguageResource {
    /// <summary>Resource: text translation.</summary>
    public const string TranslateText = "translate_text";

    /// <summary>Resource: document translation.</summary>
    public const string TranslateDocument = "translate_document";

    /// <summary>Resource: glossaries.</summary>
    public const string Glossary = "glossary";

    /// <summary>Resource: voice.</summary>
    public const string Voice = "voice";

    /// <summary>Resource: write (rephrase).</summary>
    public const string Write = "write";

    /// <summary>Resource: style rules.</summary>
    public const string StyleRules = "style_rules";

    /// <summary>Resource: translation memories.</summary>
    public const string TranslationMemory = "translation_memory";

    /// <summary>Initializes a new instance of <see cref="LanguageResource" />.</summary>
    /// <param name="name">Resource identifier, for example "translate_text".</param>
    /// <param name="features">Map of feature name to <see cref="ResourceFeature" />.</param>
    public LanguageResource(string name, IReadOnlyDictionary<string, ResourceFeature> features) {
      Name = name;
      Features = features;
    }

    /// <summary>Resource identifier, for example "translate_text" or "glossary".</summary>
    public string Name { get; }

    /// <summary>Map of feature name to <see cref="ResourceFeature" /> for each feature supported by this resource.</summary>
    public IReadOnlyDictionary<string, ResourceFeature> Features { get; }

    /// <summary>Returns <c>true</c> if this resource supports the given feature.</summary>
    /// <param name="feature">Feature name, for example <see cref="LanguageFeature.Formality" />.</param>
    public bool Supports(string feature) => Features.ContainsKey(feature);

    /// <summary>Returns the name of the resource.</summary>
    public override string ToString() => Name;
  }

  /// <summary>
  ///   A feature of a DeepL API resource, as returned by <see cref="DeepLClient.GetLanguageResourcesAsync" />.
  /// </summary>
  public sealed class ResourceFeature {
    /// <summary>Initializes a new instance of <see cref="ResourceFeature" />.</summary>
    /// <param name="name">Feature identifier, for example "formality".</param>
    /// <param name="needsSourceSupport"><c>true</c> if the source language must support this feature.</param>
    /// <param name="needsTargetSupport"><c>true</c> if the target language must support this feature.</param>
    public ResourceFeature(string name, bool needsSourceSupport, bool needsTargetSupport) {
      Name = name;
      NeedsSourceSupport = needsSourceSupport;
      NeedsTargetSupport = needsTargetSupport;
    }

    /// <summary>Feature identifier, matching the keys of <see cref="LanguageSupport.Features" />.</summary>
    public string Name { get; }

    /// <summary><c>true</c> if the source language must support this feature for it to be available.</summary>
    public bool NeedsSourceSupport { get; }

    /// <summary><c>true</c> if the target language must support this feature for it to be available.</summary>
    public bool NeedsTargetSupport { get; }
  }
}
