// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Bicep.Core.TypeSystem.Radius.V3
{
    internal static class CommonTraits
    {
        public static readonly StringLiteralType DaprTraitKindType = new StringLiteralType("dapr.io/App@v1alpha1");

        public static readonly ObjectType DaprTraitType = new ObjectType(
            "dapr.io/App@v1alpha1",
            validationFlags: TypeSymbolValidationFlags.WarnOnTypeMismatch,
            properties: new[]
            {
                new TypeProperty("kind", DaprTraitKindType, TypePropertyFlags.Required),
                new TypeProperty("appId", LanguageConstants.String, TypePropertyFlags.Required),
                new TypeProperty("appPort", LanguageConstants.Int, TypePropertyFlags.None),
                new TypeProperty("provides", LanguageConstants.String, TypePropertyFlags.None),
            },
            additionalPropertiesType: LanguageConstants.Any,
            additionalPropertiesFlags: TypePropertyFlags.None);

        public static readonly StringLiteralType DaprSidecarTraitKindType = new StringLiteralType("dapr.io/Sidecar@v1alpha1");

        public static readonly ObjectType DaprSidecarTraitType = new ObjectType(
            "dapr.io/Sidecar@v1alpha1",
            validationFlags: TypeSymbolValidationFlags.WarnOnTypeMismatch,
            properties: new[]
            {
                new TypeProperty("kind", DaprSidecarTraitKindType, TypePropertyFlags.Required),
                new TypeProperty("appId", LanguageConstants.String, TypePropertyFlags.None),
                new TypeProperty("appPort", LanguageConstants.Int, TypePropertyFlags.None),
                new TypeProperty("config", LanguageConstants.String, TypePropertyFlags.None),
                new TypeProperty("protocol", UnionType.Create(new[]{ new StringLiteralType("grpc"), new StringLiteralType("http"), }), TypePropertyFlags.None),
                new TypeProperty("provides", LanguageConstants.String, TypePropertyFlags.None),
            },
            additionalPropertiesType: LanguageConstants.Any,
            additionalPropertiesFlags: TypePropertyFlags.None);

        public static readonly StringLiteralType ManualScalingTraitKindType = new StringLiteralType("radius.dev/ManualScaling@v1alpha1");

        public static readonly ObjectType ManualScalingTraitType = new ObjectType(
            "radius.dev/ManualScaling@v1alpha",
            validationFlags: TypeSymbolValidationFlags.WarnOnTypeMismatch,
            properties: new[]
            {
                new TypeProperty("kind", ManualScalingTraitKindType, TypePropertyFlags.Required),
                new TypeProperty("replicas", LanguageConstants.Int, TypePropertyFlags.None),
            },
            additionalPropertiesType: LanguageConstants.Any,
            additionalPropertiesFlags: TypePropertyFlags.None);

        public static readonly DiscriminatedObjectType TraitType = new DiscriminatedObjectType("trait", TypeSymbolValidationFlags.WarnOnTypeMismatch, "kind", new[]
        {
            DaprTraitType,
            DaprSidecarTraitType,
            ManualScalingTraitType,
        });

        public static readonly TypedArrayType TraitArrayType = new TypedArrayType(TraitType, TypeSymbolValidationFlags.Default);
    }
}
