// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using Azure.Bicep.Types.Radius.Index;
using Azure.Bicep.Types.Concrete;

namespace Azure.Bicep.Types.Radius
{
    public interface ITypeLoader
    {
        ResourceType LoadResourceType(TypeLocation location);

        TypeIndex GetIndexedTypes();
    }
}