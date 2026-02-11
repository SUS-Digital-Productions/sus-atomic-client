using SUS.Atomic.Base.Interfaces;
using SUS.Atomic.Base.Exceptions;
using SUS.AtomicAssets.Client.Responses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
namespace SUS.AtomicAssets.Client
{
    public static class LimitableExtensionMethods
    {
        public static Type Limit<Type>(this ILimitable<Type> limitable, int limit)
        {
            limitable.AddQuery("limit", limit.ToString());
            return (Type)limitable;
        }
    }
    public static class OrderableExtensionMethods
    {
        public static Type Order<Type>(this IOrderable<Type> orderable, bool ascending = true)
        {
            if (ascending)
                orderable.AddQuery("order", "asc");
            else
                orderable.AddQuery("order", "desc");
            return (Type)orderable;
        }
    }
    public static class ExecutableExtensionMethods
    {
        public static async Task<Response> Execute<Response>(this IExecutable<Response> executable, IHttpClientFactory factory)
        {
            var client = factory.CreateClient();
            var response = await client.GetAsync(executable.GetURI());
            Response result = await response.Content.ReadAsAsync<Response>();
            return result;
        }
        public static async Task<Response> Execute<Response>(this IExecutable<Response> executable)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(executable.GetURI());
            if (response.IsSuccessStatusCode)
            {
                Response result = await response.Content.ReadAsAsync<Response>();
                return result;
            }
            ErrorResponse errorResponse = await response.Content.ReadAsAsync<ErrorResponse>();
            throw new AtomicApiException(errorResponse.Message);
        }
    }

    public static class PageableExtensionMethods
    {
        public static Type Page<Type>(this IPageable<Type> pageable, int page)
        {
            pageable.AddQuery("page", page.ToString());
            return (Type)pageable;
        }
    }
    public static class SchemaFilterableExtensionMethods
    {
        public static Type Schema<Type>(this ISchemaFilterable<Type> schemaFilterable, string schema)
        {
            schemaFilterable.AddQuery("schema_name", schema);
            return (Type)schemaFilterable;
        }
    }
    public static class CollectionFilterableExtensionMethods
    {
        public static Type Collection<Type>(this ICollectionFilterable<Type> collectionFilterable, string collection)
        {
            collectionFilterable.AddQuery("collection_name", collection);
            return (Type)collectionFilterable;
        }

        public static Type Collections<Type>(this ICollectionsFilterable<Type> collectionsFilterable, List<string> collections)
        {
            collectionsFilterable.AddMultiArgQuery("collection_name", collections);
            return (Type)collectionsFilterable;
        }
    }

    public static class OwnerMatchableExtensionMethods
    {
        public static Type OwnerMatch<Type>(this IOwnerMatchable<Type> ownerMatchable, string ownerMatch)
        {
            ownerMatchable.AddQuery("match_owner", ownerMatch);
            return (Type)ownerMatchable;
        }
    }

    public static class TemplateFilterableExtensionMethods
    {
        public static Type Template<Type>(this ITemplateFilterable<Type> templateFilterable, long template)
        {
            templateFilterable.AddQuery("template_id", template.ToString());
            return (Type)templateFilterable;
        }

        public static Type Templates<Type>(this ITemplatesFilterable<Type> templatesFilterable, List<long> templates)
        {
            templatesFilterable.AddMultiArgQuery("template_id", templates.Select(t => t.ToString()).ToList());
            return (Type)templatesFilterable;
        }
    }

    public static class BurnedAssetFilterableExtensionMethods
    {
        public static Type Burned<Type>(this IBurnedAssetsFilterable<Type> burnedAssetsFilterable, bool burned)
        {
            burnedAssetsFilterable.AddQuery("burned", burned.ToString());
            return (Type)burnedAssetsFilterable;
        }
    }

    public static class AssetOfferFilterableExtensionMethods
    {
        public static Type HideOffers<Type>(this IAssetOfferFilterable<Type> assetOfferFilterable, bool hideOffers)
        {
            assetOfferFilterable.AddQuery("hide_offers", hideOffers.ToString());
            return (Type)assetOfferFilterable;
        }
    }

    public static class CollectionBlocklistableExtensionMethods
    {
        public static Type BlocklistCollections<Type>(this ICollectionsBlocklistable<Type> collectionBlocklistable, List<string> collections)
        {
            collectionBlocklistable.AddMultiArgQuery("collection_blacklist", collections);
            return (Type)collectionBlocklistable;
        }
    }

    public static class CollectionAllowlistableExtensionMethods
    {
        public static Type AllowlistCollections<Type>(this ICollectionsAllowlistable<Type> collectionAllowlistable, List<string> collections)
        {
            collectionAllowlistable.AddMultiArgQuery("collection_whitelist", collections);
            return (Type)collectionAllowlistable;
        }
    }

    public static class OwnerFilterableExtensionMethods
    {
        /// <summary>
        /// Filters the query by owner account name.
        /// </summary>
        /// <typeparam name="Type">The type of the implementing endpoint.</typeparam>
        /// <param name="ownerFilterable">The endpoint that supports owner filtering.</param>
        /// <param name="owner">The account name of the owner to filter by.</param>
        /// <returns>The endpoint instance for method chaining.</returns>
        public static Type Owner<Type>(this IOwnerFilterable<Type> ownerFilterable, string owner)
        {
            ownerFilterable.AddQuery("owner", owner);
            return (Type)ownerFilterable;
        }

        /// <summary>
        /// Filters the query by owner account name.
        /// Legacy method kept for backward compatibility.
        /// </summary>
        /// <typeparam name="Type">The type of the implementing endpoint.</typeparam>
        /// <param name="ownerFillterable">The endpoint that supports owner filtering.</param>
        /// <param name="owner">The account name of the owner to filter by.</param>
        /// <returns>The endpoint instance for method chaining.</returns>
        [Obsolete("Use the Owner method with IOwnerFilterable instead.")]
        public static Type Owner<Type>(this IOwnerFillterable<Type> ownerFillterable, string owner)
        {
            ownerFillterable.AddQuery("owner", owner);
            return (Type)ownerFillterable;
        }

        public static Type Owners<Type>(this IOwnersFilterable<Type> ownersFilterable, List<string> owners)
        {
            ownersFilterable.AddMultiArgQuery("owner", owners);
            return (Type)ownersFilterable;
        }
    }

    public static class IdFilterableExtensionMethods
    {
        public static Type Ids<Type>(this IIdsFilterable<Type> idsFilterable, List<string> ids)
        {
            idsFilterable.AddMultiArgQuery("ids", ids);
            return (Type)idsFilterable;
        }
    }

    public static class LowerBoundableExtensionMethods
    {
        public static Type LowerBound<Type>(this ILowerBoundable<Type> lowerBoundable, long lowerBound)
        {
            lowerBoundable.AddQuery("lower_bound", lowerBound.ToString());
            return (Type)lowerBoundable;
        }
    }

    public static class UpperBoundableExtensionMethods
    {
        public static Type UpperBound<Type>(this IUpperBoundable<Type> upperBoundable, long upperBound)
        {
            upperBoundable.AddQuery("upper_bound", upperBound.ToString());
            return (Type)upperBoundable;
        }
    }

    public static class BurnedByAccountFilterableExtensionMethods
    {
        public static Type BurnedByAccounts<Type>(this IBurnedByAccountFilterable<Type> burnedByAccountFilterable, List<string> accounts)
        {
            burnedByAccountFilterable.AddMultiArgQuery("burned_by_account", accounts);
            return (Type)burnedByAccountFilterable;
        }
    }

    public static class AuthorizedAccountFilterableExtensionMethods
    {
        public static Type AuthorizedAcconts<Type>(this IAuthorizedAccountFilterable<Type> authorizedAccountFilterable, string account)
        {
            authorizedAccountFilterable.AddQuery("authorized_account", account);
            return (Type)authorizedAccountFilterable;
        }
    }

    public static class MatchableExtensionMethods
    {
        public static Type Match<Type>(this IMatchable<Type> matchable, string match)
        {
            matchable.AddQuery("match", match);
            return (Type)matchable;
        }
    }

    public static class BeforeFilterableExtensionMethods
    {
        public static Type Before<Type>(this IBeforeFilterable<Type> beforeFilterable, string before)
        {
            beforeFilterable.AddQuery("before", before);
            return (Type)beforeFilterable;
        }
    }

    public static class AfterFilterableExtensionMethods
    {
        public static Type After<Type>(this IAfterFilterable<Type> afterFilterable, string after)
        {
            afterFilterable.AddQuery("after", after);
            return (Type)afterFilterable;
        }
    }

    public static class SortableExtensionMethods
    {
        public static Type Sort<Type, Enum>(this ISortable<Type, Enum> sortable, Enum sort)
        {
            sortable.AddQuery("sort", sort.ToString().ToLower());
            return (Type)sortable;
        }
    }

    public static class ActionAllowlistableExtensionMethods
    {
        public static Type ActionAllowlistable<Type>(this IActionAllowlistable<Type> actionAllowlistable, string action)
        {
            actionAllowlistable.AddQuery("action_whitelist", action);
            return (Type)actionAllowlistable;
        }
    }

    public static class ActionBlocklistableExtensionMethods
    {
        public static Type ActionBlocklist<Type>(this IActionBlocklistable<Type> actionBlocklistable, string action)
        {
            actionBlocklistable.AddQuery("action_blacklist", action);
            return (Type)actionBlocklistable;
        }
    }

    public static class AccountFilterableExtensionMethods
    {
        public static Type Accounts<Type>(this IAccountFilterable<Type> accountFilterable, List<string> accounts)
        {
            accountFilterable.AddMultiArgQuery("account", accounts);
            return (Type)accountFilterable;
        }
    }

    public static class SenderFilterableExtensionMethods
    {
        public static Type Senders<Type>(this ISendersFilterable<Type> sendersFilterable, List<string> senders)
        {
            sendersFilterable.AddMultiArgQuery("sender", senders);
            return (Type)sendersFilterable;
        }
    }

    public static class RecipientFilterableExtensionMethods
    {
        public static Type Receivers<Type>(this IRecipientsFilterable<Type> recipientsFilterable, List<string> recipients)
        {
            recipientsFilterable.AddMultiArgQuery("recipient", recipients);
            return (Type)recipientsFilterable;
        }
    }

    public static class MemoFilterableExtensionMethods
    {
        public static Type Memo<Type>(this IMemoFilterable<Type> memoFilterable, string memo)
        {
            memoFilterable.AddQuery("memo", memo);
            return (Type)memoFilterable;
        }
    }

    public static class MemoMatchableExtensionMethods
    {
        public static Type MatchMemo<Type>(this IMemoMatchable<Type> memoMatchable, string match)
        {
            memoMatchable.AddQuery("memo_match", match);
            return (Type)memoMatchable;
        }
    }

    public static class StateFilterableExtensionMethods
    {
        public static Type State<Type, TEnum>(this IStateFilterable<Type, TEnum> stateFilterable, List<TEnum> states) where TEnum : Enum
        {
            stateFilterable.AddMultiArgQuery("state", states.Select(state => Convert.ToInt32(state).ToString()).ToList());
            return (Type)stateFilterable;
        }
    }

    public static class IsRecipientContractFilterableExtensionMethhods
    {
        public static Type IsRecipientContract<Type>(this IIsRecipientContractFilterable<Type> isRecipientContractFilterable, bool isRecipientContract)
        {
            isRecipientContractFilterable.AddQuery("is_recipient_contract", isRecipientContract.ToString());
            return (Type)isRecipientContractFilterable;
        }
    }

    public static class AssetFilterableExtensionMethods
    {
        public static Type Asset<Type>(this IAssetFilterable<Type> assetFilterable, long assetId)
        {
            assetFilterable.AddQuery("asset_id", assetId.ToString());
            return (Type)assetFilterable;
        }

        public static Type Assets<Type>(this IAssetsFilterable<Type> assetsFilterable, List<long> assets)
        {
            assetsFilterable.AddMultiArgQuery("asset_id", assets.Select(asset => asset.ToString()).ToList());
            return (Type)assetsFilterable;
        }
    }

    public static class SearchableExtensionMethods
    {
        public static Type Search<Type>(this ISearchable<Type> searchable, string search)
        {
            searchable.AddQuery("search", search);
            return (Type)searchable;
        }
    }

    public static class NameMatchable
    {
        public static Type MatchImmutableName<Type>(this IImmutableNameMatchable<Type> nameMatchable, string name)
        {
            nameMatchable.AddQuery("match_immutable_name", name);
            return (Type)nameMatchable;
        }

        public static Type MatchMutableName<Type>(this IMutableNameMatchable<Type> nameMatchable, string name)
        {
            nameMatchable.AddQuery("match_mutable_name", name);
            return (Type)nameMatchable;
        }
    }

    public static class IsTransferableExtensionMethods
    {
        public static Type IsTransferable<Type>(this IIsTransferable<Type> isTransferable, bool isTransferableBool)
        {
            isTransferable.AddQuery("is_transferable", isTransferableBool.ToString());
            return (Type)isTransferable;
        }
    }

    public static class IsBurnableExtensionMethods
    {
        public static Type IsBurnable<Type>(this IIsBurnable<Type> isBurnable, bool isBurnableBool)
        {
            isBurnable.AddQuery("is_burnable", isBurnableBool.ToString());
            return (Type)isBurnable;
        }
    }

    public static class MinterFilterableExtensionMethods
    {
        public static Type Minter<Type>(this IMinterFilterable<Type> minterFilterable, string minter)
        {
            minterFilterable.AddQuery("minter", minter);
            return (Type)minterFilterable;
        }
    }

    public static class BurnerFilterableExtensionMethods
    {
        public static Type Burner<Type>(this IBurnerFilterable<Type> burnerFilterable, string burner)
        {
            burnerFilterable.AddQuery("burner", burner);
            return (Type)burnerFilterable;
        }
    }

    public static class InitialReceiverFilterableExtensionMethods
    {
        public static Type InitialReceiver<Type>(this IInitialReceiverFilterable<Type> initialReceiverFilterable, string initialReceiver)
        {
            initialReceiverFilterable.AddQuery("initial_receiver", initialReceiver);
            return (Type)initialReceiverFilterable;
        }
    }

    public static class OnlyDuplicateTemplateFilterableExtensionMethods
    {
        public static Type OnlyDuplicateTemplates<Type>(this IOnlyDuplicateTemplatesFilterable<Type> onlyDuplicateTemplatesFilterable, bool onlyDuplicates)
        {
            onlyDuplicateTemplatesFilterable.AddQuery("only_duplicate_templates", onlyDuplicates.ToString());
            return (Type)onlyDuplicateTemplatesFilterable;
        }
    }

    public static class HasBackedTokenExtensionMethods
    {
        public static Type HasBackedTokens<Type>(this IHasBackedTokens<Type> hasBackedTokensFilterable, bool hasBackedTokens)
        {
            hasBackedTokensFilterable.AddQuery("has_backed_tokens", hasBackedTokens.ToString());
            return (Type)hasBackedTokensFilterable;
        }
    }

    public static class HasTemplateBuyofferExtensionMethods
    {
        public static Type HasTemplateBuyOffer<Type>(this IHasTemplateBuyoffer<Type> hasTemplateBuyofferFilterable, bool hasTemplateBuyOffer)
        {
            hasTemplateBuyofferFilterable.AddQuery("has_template_buyoffer", hasTemplateBuyOffer.ToString());
            return (Type)hasTemplateBuyofferFilterable;
        }
    }

    public static class TemplateBlocklistableExtensionMethods
    {
        public static Type BlockTemplates<Type>(this ITemplatesBlocklistable<Type> templateBlocklistable, List<long> templates)
        {
            templateBlocklistable.AddMultiArgQuery("template_blacklist", templates.Select(template => template.ToString()).ToList());
            return (Type)templateBlocklistable;
        }
    }

    public static class TemplateAllowlistableExtensionMethods
    {
        public static Type AllowTemplates<Type>(this ITemplatesAllowlistable<Type> templateAllowlistable, List<long> templates)
        {
            templateAllowlistable.AddMultiArgQuery("template_whitelist", templates.Select(template => template.ToString()).ToList());
            return (Type)templateAllowlistable;
        }
    }

    public static class HideTemplateByAccountExtensionMethods
    {
        public static Type HideTemplatesByAccounts<Type>(this IHideTemplatesByAccounts<Type> hideTemplatesByAccountsFilterable, string account)
        {
            hideTemplatesByAccountsFilterable.AddQuery("hide_templates_by_accounts", account);
            return (Type)hideTemplatesByAccountsFilterable;
        }
    }

    public static class BuyerFilterableExtensionMethods
    {
        public static Type Buyer<Type>(this IBuyerFilterable<Type> buyerFilterable, string buyer)
        {
            buyerFilterable.AddQuery("buyer", buyer);
            return (Type)buyerFilterable;
        }

        public static Type Buyers<Type>(this IBuyersFilterable<Type> buyersFilterable, List<string> buyers)
        {
            buyersFilterable.AddMultiArgQuery("buyer", buyers);
            return (Type)buyersFilterable;
        }
    }

    public static class SellerFilterableExtensionMethods
    {
        public static Type Seller<Type>(this ISellerFilterable<Type> sellerFilterable, string seller)
        {
            sellerFilterable.AddQuery("seller", seller);
            return (Type)sellerFilterable;
        }

        public static Type Sellers<Type>(this ISellersFilterable<Type> sellersFilterable, List<string> sellers)
        {
            sellersFilterable.AddMultiArgQuery("seller", sellers);
            return (Type)sellersFilterable;
        }
    }

    public static class TokenSymbolFilterableExtensionMethods
    {
        public static Type TokenSymbol<Type>(this ITokenSymbolFilterable<Type> tokenSymbolFilterable, string tokenSymbol)
        {
            tokenSymbolFilterable.AddQuery("symbol", tokenSymbol);
            return (Type)tokenSymbolFilterable;
        }
    }

    public static class AuthorFilterableExtensionMethods
    {
        public static Type Author<Type>(this IAuthorFilterable<Type> authorFilterable, string author)
        {
            authorFilterable.AddQuery("author", author);
            return (Type)authorFilterable;
        }
    }

    public static class NotifyAccountFilterableExtensionMethods
    {
        public static Type NotifyAccount<Type>(this INotifyAccountFilterable<Type> notifyAccountFilterable, string notifyAccount)
        {
            notifyAccountFilterable.AddQuery("notify_account", notifyAccount);
            return (Type)notifyAccountFilterable;
        }
    }

    public static class IssuedSupplyFilterableExtensionMethods
    {
        public static Type IssuedSupply<Type>(this IIssuedSupplyFilterable<Type> issuedSupplyFilterable, int issuedSupply)
        {
            issuedSupplyFilterable.AddQuery("issued_supply", issuedSupply.ToString());
            return (Type)issuedSupplyFilterable;
        }
    }

    public static class MinIssuedSupplyFilterableExtensionMethods
    {
        public static Type MinIssuedSupply<Type>(this IMinIssuedSupplyFilterable<Type> minIssuedSupplyFilterable, int minIssuedSupply)
        {
            minIssuedSupplyFilterable.AddQuery("min_issued_supply", minIssuedSupply.ToString());
            return (Type)minIssuedSupplyFilterable;
        }
    }

    public static class MaxIssuedSupplyFilterableExtensionMethods
    {
        public static Type MaxIssuedSupply<Type>(this IMaxIssuedSupplyFilterable<Type> maxIssuedSupplyFilterable, int maxIssuedSupply)
        {
            maxIssuedSupplyFilterable.AddQuery("max_issued_supply", maxIssuedSupply.ToString());
            return (Type)maxIssuedSupplyFilterable;
        }
    }

    public static class HasAssetExtensionMethods
    {
        public static Type HasAssets<Type>(this IHasAssets<Type> hasAssets, bool has)
        {
            hasAssets.AddQuery("has_assets", has.ToString());
            return (Type)hasAssets;
        }
    }

    public static class MaxSupplyFilterableExtensionMethods
    {
        public static Type MaxSupply<Type>(this IMaxSupplyFilterable<Type> maxSupplyFilterable, int maxSupply)
        {
            maxSupplyFilterable.AddQuery("max_supply", maxSupply.ToString());
            return (Type)maxSupplyFilterable;
        }
    }

    public static class HideContractExtensionMethods
    {
        public static Type HideContracts<Type>(this IHideContracts<Type> hideContracts, bool hide)
        {
            hideContracts.AddQuery("hide_contracts", hide.ToString());
            return (Type)hideContracts;
        }
    }

    public static class TransferFilterableExtensionMethods
    {
        public static Type Transfers<Type>(this ITransfersFilterable<Type> transfersFilterable, List<long> transfers)
        {
            transfersFilterable.AddMultiArgQuery("transfer_id", transfers.Select(t => t.ToString()).ToList());
            return (Type)transfersFilterable;
        }
    }

    public static class CreatorFilterableExtensionMethods
    {
        public static Type Creator<Type>(this ICreatorFilterable<Type> creatorFilterable, string creator)
        {
            creatorFilterable.AddQuery("creator", creator);
            return (Type)creatorFilterable;
        }
    }

    public static class ClaimerFilterableExtensionMethods
    {
        public static Type Claimer<Type>(this IClaimerFilterable<Type> claimerFilterable, string claimer)
        {
            claimerFilterable.AddQuery("claimer", claimer);
            return (Type)claimerFilterable;
        }
    }

    public static class PublicKeyFilterableExtensionMethods
    {
        public static Type PublicKey<Type>(this IPublicKeyFilterable<Type> pubkeyFilterable, string pubkey)
        {
            pubkeyFilterable.AddQuery("public_key", pubkey);
            return (Type)pubkeyFilterable;
        }
    }

    public static class LinkFilterableExtensionMethods
    {
        public static Type Links<Type>(this ILinksFilterable<Type> linksFilterable, List<string> links)
        {
            linksFilterable.AddMultiArgQuery("link_id", links);
            return (Type)linksFilterable;
        }
    }

    public static class MinAssetsFilterableExtensionMethods
    {
        public static Type MinAssets<Type>(this IMinAssetsFilterable<Type> minAssetsFilterable, int minAssets)
        {
            minAssetsFilterable.AddQuery("min_assets", minAssets.ToString());
            return (Type)minAssetsFilterable;
        }
    }

    public static class MaxAssetsFilterableExtensionMethods
    {
        public static Type MaxAssets<Type>(this IMaxAssetsFilterable<Type> maxAssetsFilterable, int maxAssets)
        {
            maxAssetsFilterable.AddQuery("max_assets", maxAssets.ToString());
            return (Type)maxAssetsFilterable;
        }
    }

    public static class ShowSellerContractsExtensionMethods
    {
        public static Type ShowSellerContracts<Type>(this IShowSellerContracts<Type> showSellerContracts, bool showContracts)
        {
            showSellerContracts.AddQuery("show_seller_contracts", showContracts.ToString());
            return (Type)showSellerContracts;
        }
    }

    public static class ContractAllowlistableExtensionMethods
    {
        public static Type ContractAllowlist<Type>(this IContractAllowlistable<Type> contractAllowlistable, string contractAllowlist)
        {
            contractAllowlistable.AddQuery("contract_whitelist", contractAllowlist);
            return (Type)contractAllowlistable;
        }
    }

    public static class SellerBlocklistableExtensionMethods
    {
        public static Type SellersBlocklist<Type>(this ISellersBlocklistable<Type> sellerBlocklistable, List<string> sellers)
        {
            sellerBlocklistable.AddMultiArgQuery("seller_blacklist", sellers);
            return (Type)sellerBlocklistable;
        }
    }

    public static class BuyerBlocklistableExtensionMethods
    {
        public static Type BuyerBlocklist<Type>(this IBuyersBlocklistable<Type> buyerBlocklistable, List<string> buyers)
        {
            buyerBlocklistable.AddMultiArgQuery("buyer_blacklist", buyers);
            return (Type)buyerBlocklistable;
        }
    }

    public static class MarketplaceFilterableExtensionMethods
    {
        public static Type Marketplaces<Type>(this IMarketplacesFilterable<Type> marketplacesFilterable, List<string> marketplaces)
        {
            marketplacesFilterable.AddMultiArgQuery("marketplace", marketplaces);
            return (Type)marketplacesFilterable;
        }
    }

    public static class TakerMarketplaceFilterableExtensionMethods
    {
        public static Type TakerMarketplaces<Type>(this ITakerMarketplacesFilterable<Type> takerMarketplaceFilterable, List<string> takerMarketplaces)
        {
            takerMarketplaceFilterable.AddMultiArgQuery("taker_marketplace", takerMarketplaces);
            return (Type)takerMarketplaceFilterable;
        }
    }

    public static class MakerMarketplaceFilterableExtensionMethods
    {
        public static Type MakerMarketplace<Type>(this IMakerMarketplacesFilterable<Type> makerMarketplacesFilterable, List<string> makerMarketplaces)
        {
            makerMarketplacesFilterable.AddMultiArgQuery("maker_marketplace", makerMarketplaces);
            return (Type)makerMarketplacesFilterable;
        }
    }

    public static class MinPriceFilterableExtensionMethods
    {
        public static Type MinPrice<Type>(this IMinPriceFilterable<Type> minPriceFilterable, double minPrice)
        {
            minPriceFilterable.AddQuery("min_price", minPrice.ToString());
            return (Type)minPriceFilterable;
        }
    }

    public static class MaxPriceFilterableExtensionMethods
    {
        public static Type MaxPrice<Type>(this IMaxPriceFilterable<Type> maxPriceFilterable, double maxPrice)
        {
            maxPriceFilterable.AddQuery("max_price", maxPrice.ToString());
            return (Type)maxPriceFilterable;
        }
    }

    public static class MinTemplateMintFilterableExtensionMethods
    {
        public static Type MinTemplateMint<Type>(this IMinTemplateMintFilterable<Type> minTemplateMintFilterable, int minTemplateMint)
        {
            minTemplateMintFilterable.AddQuery("min_template_mint", minTemplateMint.ToString());
            return (Type)minTemplateMintFilterable;
        }
    }

    public static class MaxTemplateMintFilterableExtensionMethods
    {
        public static Type MaxTemplateMint<Type>(this IMaxTemplateMintFilterable<Type> maxTemplateMintFilterable, int maxTemplateMint)
        {
            maxTemplateMintFilterable.AddQuery("max_template_mint", maxTemplateMint.ToString());
            return (Type)maxTemplateMintFilterable;
        }
    }

    public static class SaleFilterableExtensionMethods
    {
        public static Type Sales<Type>(this ISalesFilterable<Type> salesFilterable, List<long> sales)
        {
            salesFilterable.AddMultiArgQuery("sale_id", sales.Select(sale => sale.ToString()).ToList());
            return (Type)salesFilterable;
        }
    }

    public static class BidderFilterableExtensionMethods
    {
        public static Type Bidder<Type>(this IBidderFilterable<Type> bidderFilterable, string bidder)
        {
            bidderFilterable.AddQuery("bidder", bidder);
            return (Type)bidderFilterable;
        }
    }

    public static class ParticipantFilterableExtensionMethods
    {
        public static Type Participant<Type>(this IParticipantFilterable<Type> participantFilterable, string participant)
        {
            participantFilterable.AddQuery("participant", participant);
            return (Type)participantFilterable;
        }
    }

    public static class HideEmptyAuctionsExtensionMethods
    {
        public static Type HideEmptyAuctions<Type>(this IHideEmptyAuctions<Type> hideEmptyAuctions, bool hide)
        {
            hideEmptyAuctions.AddQuery("hide_empty_auctions", hide.ToString());
            return (Type)hideEmptyAuctions;
        }
    }

    public static class AuctionFilterableExtensionMethods
    {
        public static Type Auctions<Type>(this IAuctionsFilterable<Type> auctionsFilterable, List<long> auctions)
        {
            auctionsFilterable.AddMultiArgQuery("auction_id", auctions.Select(auction => auction.ToString()).ToList());
            return (Type)auctionsFilterable;
        }
    }

    public static class AccountAllowlistableExtensionMethods
    {
        public static Type AllowedAccounts<Type>(this IAccountAllowlistable<Type> accountAllowlistable, string account)
        {
            accountAllowlistable.AddQuery("account_whitelist", account);
            return (Type)accountAllowlistable;
        }
    }

    public static class AccountBlocklistableExtensionMethods
    {
        public static Type BlockedAccounts<Type>(this IAccountBlocklistable<Type> accountBlocklistable, string account)
        {
            accountBlocklistable.AddQuery("account_blacklist", account);
            return (Type)accountBlocklistable;
        }
    }

    public static class SenderAssetAllowlistableExtensionMethods
    {
        public static Type AllowSenderAsset<Type>(this ISenderAssetAllowlistable<Type> senderAssetAllowlistable, long assetId)
        {
            senderAssetAllowlistable.AddQuery("sender_asset_whitelist", assetId.ToString());
            return (Type)senderAssetAllowlistable;
        }
    }

    public static class SenderAssetBlocklistableExtensionMethods
    {
        public static Type BlockSenderAsset<Type>(this ISenderAssetBlocklistable<Type> senderAssetBlocklistable, long assetId)
        {
            senderAssetBlocklistable.AddQuery("sender_asset_blacklist", assetId.ToString());
            return (Type)senderAssetBlocklistable;
        }
    }

    public static class RecipientAssetAllowlistableExtensionMethods
    {
        public static Type AllowRecipientAsset<Type>(this IRecipientAssetAllowlistable<Type> recipientAssetAllowlistable, long assetId)
        {
            recipientAssetAllowlistable.AddQuery("recipient_asset_whitelist", assetId.ToString());
            return (Type)recipientAssetAllowlistable;
        }
    }

    public static class RecipientAssetBlocklistableExtensionMethods
    {
        public static Type BlockRecipientAsset<Type>(this IRecipientAssetBlocklistable<Type> recipientAssetBlocklistable, long assetId)
        {
            recipientAssetBlocklistable.AddQuery("recipient_asset_blacklist", assetId.ToString());
            return (Type)recipientAssetBlocklistable;
        }
    }

    public static class HideEmptyOffersExtensionMethods
    {
        public static Type HideEmptyOffers<Type>(this IHideEmptyOffers<Type> hideEmptyOffers, bool hide)
        {
            hideEmptyOffers.AddQuery("hide_empty_offers", hide.ToString());
            return (Type)hideEmptyOffers;
        }
    }

    public static class OfferFilterableExtensionMethods
    {
        public static Type Offers<Type>(this IOffersFilterable<Type> offerFilterable, List<long> offers)
        {
            offerFilterable.AddMultiArgQuery("offer_id", offers.Select(offer => offer.ToString()).ToList());
            return (Type)offerFilterable;
        }
    }

    public static class BuyofferFilterableExtensionMethods
    {
        public static Type Buyoffers<Type>(this IBuyofferFilterable<Type> buyofferFilterable, List<long> buyoffers)
        {
            buyofferFilterable.AddMultiArgQuery("buyoffer_id", buyoffers.Select(buyoffer => buyoffer.ToString()).ToList());
            return (Type)buyofferFilterable;
        }
    }

    public static class HideUnlistedTemplatesExtensionMethods
    {
        public static Type HideUnlistedTemplates<Type>(this IHideUnlistedTemplates<Type> hideUnlistedTemplates, bool hide)
        {
            hideUnlistedTemplates.AddQuery("hide_unlisted_templates", hide.ToString());
            return (Type)hideUnlistedTemplates;
        }
    }
}